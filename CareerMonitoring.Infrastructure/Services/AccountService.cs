using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class AccountService : IAccountService {
        private readonly IAccountRepository _accountRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IGraduateRepository _graduateRepository;
        private readonly IAccountEmailFactory _accountEmailFactory;

        public AccountService (IAccountRepository accountRepository,
            IStudentRepository studentRepository,
            IEmployerRepository employerRepository,
            IGraduateRepository graduateRepository,
            IAccountEmailFactory accountEmailFactory) {
            _accountRepository = accountRepository;
            _studentRepository = studentRepository;
            _employerRepository = employerRepository;
            _graduateRepository = graduateRepository;
            _accountEmailFactory = accountEmailFactory;
        }
        public async Task<bool> ExistsByIdAsync (int id) =>
            await _accountRepository.GetByIdAsync (id) != null;

        public async Task<bool> ExistsByEmailAsync (string email) =>
            await _accountRepository.GetByEmailAsync (email) != null;

        public async Task<Account> GetActiveByEmailAsync (string email, bool isTracking = true) {
            var account = await _accountRepository.GetByEmailAsync (email, isTracking);
            if (account == null || account.Deleted || !account.Activated)
                return null;
            return account;
        }

        public async Task<Account> GetActiveWithAccountRestoringPasswordByTokenAsync (Guid token, bool isTracking = true) {
            var account = await _accountRepository.GetWithAccountRestoringPasswordByTokenAsync (token, isTracking);
            if (account == null || account.Deleted || !account.Activated)
                return null;
            return account;
        }

        public async Task ActivateAsync (Guid activationKey) {
            var account = await _accountRepository.GetByActivationKeyAsync (activationKey);
            if (account == null) {
                throw new Exception ("Your activation key is incorrect.");
            }
            account.Activate (account.AccountActivation);
            await _accountRepository.UpdateAsync (account);
        }

        public async Task RestorePasswordAsync (Account account) {
            var token = Guid.NewGuid ();
            var accountToPaswordRestor = await _accountRepository.GetWithAccountRestoringPasswordAsync (account.Id);
            if (accountToPaswordRestor.AccountRestoringPassword != null && accountToPaswordRestor.Activated == true && accountToPaswordRestor.Deleted == false)
                accountToPaswordRestor.ChangeAccountRestoringPassword (token);
            else
                accountToPaswordRestor.AddAccountRestoringPassword (new AccountRestoringPassword (token));
            await _accountEmailFactory.SendRecoveringPasswordEmailAsync (accountToPaswordRestor, token);
            await _accountRepository.UpdateAsync (accountToPaswordRestor);
        }

        public async Task UpdatePasswordAsync (Account account, string newPassword) {
            account.UpdatePassword (newPassword);
            await _accountRepository.UpdateAsync (account);
        }

        public async Task ChangePasswordByRestoringPassword (string accountEmail, Guid token, string newPassword) {
            var account = await _accountRepository.GetWithAccountRestoringPasswordByTokenAsync (token);
            if (account == null || account.AccountRestoringPassword == null || account.AccountRestoringPassword.Restored)
                throw new Exception ("Your token is incorrect");
            if (account.Email.ToLowerInvariant () != accountEmail.ToLowerInvariant ())
                throw new Exception ("Invalid email address");
            await UpdatePasswordAsync (account, newPassword);
            account.AccountRestoringPassword.PasswordRestoring ();
            await _accountRepository.UpdateAsync (account);
        }

        public async Task DeleteAsync (int id) {
            var account = await _accountRepository.GetByIdAsync (id);
            await _accountRepository.DeleteAsync (account);
        }

        public async Task UpdateAsync (int id, string name, string surname, string email,
            string phoneNumber, string companyName, string location, string companyDescription) {
            var account = await _accountRepository.GetByIdAsync (id);
            if (account == null) {
                throw new System.Exception ($"Account with id: '{id}' does not exist.");
            }
            if (account.GetType () == typeof (Student)) {
                var student = (Student) account;
                student.Update (name, surname, email, phoneNumber);
                await _accountRepository.UpdateAsync (student);
                account = student;
            }
            if (account.GetType () == typeof (Graduate)) {
                var graduate = (Graduate) account;
                graduate.Update (name, surname, email, phoneNumber);
                await _accountRepository.UpdateAsync (graduate);
                account = graduate;
            }
            if (account.GetType () == typeof (Employer)) {
                var employer = (Employer) account;
                employer.Update (name, surname, phoneNumber, companyName, location, companyDescription);
                await _employerRepository.UpdateAsync (employer);
                account = employer;
            }
            await _accountRepository.UpdateAsync (account);
        }
    }
}