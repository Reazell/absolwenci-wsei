using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Extensions.ExceptionHandling;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class AccountService : IAccountService {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountEmailFactory _accountEmailFactory;
        private readonly ICareerOfficeRepository _careerOfficeRepository;

        public AccountService (IAccountRepository accountRepository,
            IAccountEmailFactory accountEmailFactory,
            ICareerOfficeRepository careerOfficeRepository) {
            _accountRepository = accountRepository;
            _accountEmailFactory = accountEmailFactory;
            _careerOfficeRepository = careerOfficeRepository;
        }

        public async Task<bool> ExistsByEmailAsync (string email) =>
            await _accountRepository.GetByEmailAsync (email) != null;

        public async Task<Account> GetActiveByEmailAsync (string email, bool isTracking = true) {
            var account = await _accountRepository.GetByEmailAsync (email, isTracking);
            if (account == null || account.Deleted || !account.Activated) {
                return null;
            }
            return account;
        }

        public async Task<Account> GetActiveWithAccountRestoringPasswordByTokenAsync (Guid token, bool isTracking = true) {
            var account = await _accountRepository.GetWithAccountRestoringPasswordByTokenAsync (token, isTracking);
            if (account == null || account.Deleted || !account.Activated) {
                return null;
            }
            return account;
        }

        public async Task ActivateAsync (Guid activationKey) {
            var account = await _accountRepository.GetByActivationKeyAsync (activationKey);
            if (account == null) {
                throw new IncorrectValueException ("Your activation key is incorrect.");
            }
            account.Activate (account.AccountActivation);
            await _accountRepository.UpdateAsync (account);
        }

        public async Task RestorePasswordAsync (Account account) {
            var token = Guid.NewGuid ();
            var accountToPaswordRestor = await _accountRepository.GetWithAccountRestoringPasswordAsync (account.Id);
            if (accountToPaswordRestor.AccountRestoringPassword != null && accountToPaswordRestor.Activated == true &&
                accountToPaswordRestor.Deleted == false) {
                accountToPaswordRestor.ChangeAccountRestoringPassword (token);
            } else {
                accountToPaswordRestor.AddAccountRestoringPassword (new AccountRestoringPassword (token));
            }
            await _accountEmailFactory.SendRecoveringPasswordEmailAsync (accountToPaswordRestor, token);
            await _accountRepository.UpdateAsync (accountToPaswordRestor);
        }

        public async Task UpdatePasswordAsync (Account account, string newPassword) {
            account.UpdatePassword (newPassword);
            await _accountRepository.UpdateAsync (account);
        }

        public async Task ChangePasswordByRestoringPassword (string accountEmail, Guid token, string newPassword) {
            var account = await _accountRepository.GetWithAccountRestoringPasswordByTokenAsync (token);
            if (account == null || account.AccountRestoringPassword == null ||
                account.AccountRestoringPassword.Restored)
                throw new IncorrectValueException ("Your token is incorrect.");
            if (account.Email.ToLowerInvariant () != accountEmail.ToLowerInvariant ())
                throw new InvalidValueException ($"Invalid email: {accountEmail}");
            await UpdatePasswordAsync (account, newPassword);
            account.AccountRestoringPassword.PasswordRestoring ();
            await _accountRepository.UpdateAsync (account);
        }

        public async Task UpdateAsync (int id, string name, string surname, string email,
            string phoneNumber, string companyName, string location, string companyDescription) {
            var account = await _accountRepository.GetByIdAsync (id);
            if (account == null) {
                throw new ObjectDoesNotExistException ($"Account with id: '{id}' does not exist.");
            }
            if (account.GetType () == typeof (CareerOffice)) {
                var careerOffice = (CareerOffice) account;
                careerOffice.Update (name, surname, email, phoneNumber);
                await _careerOfficeRepository.UpdateAsync(careerOffice);
                account = careerOffice;
            }
            await _accountRepository.UpdateAsync (account);
        }

        public async Task<bool> ExistsByMaster() =>
            await _accountRepository.GetByMasterAsync() != null;
    }
}