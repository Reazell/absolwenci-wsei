using System;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IAccountService {
        Task<bool> ExistsByIdAsync (int id);
        Task<bool> ExistsByEmailAsync (string email);
        Task ActivateAsync (Guid activationKey);
        Task DeleteAsync (int id);
        Task UpdateAsync (int id, string name, string surname, string email, string phoneNumber, string companyName, string location, string companyDescription);
    }
}