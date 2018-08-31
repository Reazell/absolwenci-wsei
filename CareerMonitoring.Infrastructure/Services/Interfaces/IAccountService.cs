using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IAccountService {
        Task<bool> ExistsByIdAsync (int id);
        Task<bool> ExistsByEmailAsync (string email);
        Task<Account> GetActiveByEmailAsync (string email);
        Task ActivateAsync (Guid activationKey);
        Task RestorePasswordAsync (Account account);
        Task UpdatePasswordAsync (Account account, string newPassword);
        Task ChangePasswordByRestoringPassword (string accountEmail, Guid token, string newPassword);
        Task DeleteAsync (int id);
    }
}