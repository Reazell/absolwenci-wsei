using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IAccountService {
        Task<bool> ExistsByEmailAsync (string email);
        Task<Account> GetActiveByEmailAsync (string email, bool isTracking = true);
        Task<Account> GetActiveWithAccountRestoringPasswordByTokenAsync (Guid token, bool isTracking = true);
        Task ActivateAsync (Guid activationKey);
        Task RestorePasswordAsync (Account account);
        Task UpdatePasswordAsync (Account account, string newPassword);
        Task ChangePasswordByRestoringPassword (string accountEmail, Guid token, string newPassword);
        Task UpdateAsync(int id, string name, string surname, string email, string phoneNumber, string companyName,
            string location, string companyDescription);
        Task<bool> ExistsByMaster ();

    }
}