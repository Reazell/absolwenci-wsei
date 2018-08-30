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
        private readonly IAccountEmailFactory _accountEmailFactory;

        public AccountService (IAccountRepository accountRepository,
            IAccountEmailFactory accountEmailFactory) {
            _accountRepository = accountRepository;
            _accountEmailFactory = accountEmailFactory;
        }
        public async Task<bool> ExistsByIdAsync (int id) =>
            await _accountRepository.GetByIdAsync (id) != null;

        public async Task<bool> ExistsByEmailAsync (string email) =>
            await _accountRepository.GetByEmailAsync (email) != null;

        public async Task<Account> GetActiveByEmailAsync (string email) {
            var account = await _accountRepository.GetByEmailAsync (email, false);
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
            var accountToPaswordRestor = await _accountRepository.GetByIdAsync (account.Id);
            if (accountToPaswordRestor.AccountRestoringPassword != null && accountToPaswordRestor.Activated == true && accountToPaswordRestor.Deleted == false)
                accountToPaswordRestor.ChangeAccountRestoringPassword (token);
            else
                accountToPaswordRestor.AddUserRestoringPassword (new AccountRestoringPassword (token));
            await _accountEmailFactory.SendRecoveringPasswordEmailAsync (accountToPaswordRestor, token);
            await _accountRepository.UpdateAsync (accountToPaswordRestor);
        }

        public async Task UpdatePasswordAsync (Account account, string newPassword) {
            account.UpdatePassword (newPassword);
            await _accountRepository.UpdateAsync (account);
        }

        public async Task DeleteAsync (int id) {
            var account = await _accountRepository.GetByIdAsync (id);
            await _accountRepository.DeleteAsync (account);
        }
    }
}