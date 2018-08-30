using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class AccountService : IAccountService {
        private readonly IAccountRepository _accountRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IGraduateRepository _graduateRepository;

        public AccountService (IAccountRepository accountRepository, IStudentRepository studentRepository,
        IEmployerRepository employerRepository, IGraduateRepository graduateRepository) {
            _accountRepository = accountRepository;
            _studentRepository = studentRepository;
            _employerRepository = employerRepository;
            _graduateRepository = graduateRepository;
        }
        public async Task<bool> ExistsByIdAsync (int id) =>
            await _accountRepository.GetByIdAsync (id) != null;

        public async Task<bool> ExistsByEmailAsync (string email) =>
            await _accountRepository.GetByEmailAsync (email) != null;

        public async Task ActivateAsync (Guid activationKey) {
            var account = await _accountRepository.GetByActivationKeyAsync (activationKey);
            if (account == null) {
                throw new Exception ("Your activation key is incorrect.");
            }
            account.Activate (account.AccountActivation);
            await _accountRepository.UpdateAsync (account);
        }

        public async Task DeleteAsync (int id) {
            var account = await _accountRepository.GetByIdAsync (id);
            await _accountRepository.DeleteAsync (account);
        }

        public async Task UpdateAsync (int id, string name, string surname, string email,
        string phoneNumber, string companyName, string location, string companyDescription)
        {
            var account = await _accountRepository.GetByIdAsync (id);
            if(account == null)
            {
                throw new System.Exception($"Account with id: '{id}' does not exist.");
            }
            if(account.GetType () == typeof (Student))
            {
                var student = (Student) account;
                student.Update(name, surname, email, phoneNumber);
                await _accountRepository.UpdateAsync(student);
                account = student;
            }
            if(account.GetType () == typeof (Graduate))
            {
                var graduate = (Graduate) account;
                graduate.Update(name, surname, email, phoneNumber);
                await _accountRepository.UpdateAsync(graduate);
                account = graduate;
            }
            if(account.GetType () == typeof (Employer))
            {
                var employer = (Employer) account;
                employer.Update(name, surname, phoneNumber, companyName, location, companyDescription);
                await _employerRepository.UpdateAsync(employer);
                account = employer;
            }
            await _accountRepository.UpdateAsync (account);
        }
    }
}