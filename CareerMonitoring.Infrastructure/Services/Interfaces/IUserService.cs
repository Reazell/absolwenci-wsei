using System;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IUserService {
        Task ActivateAsync (Guid activationKey);
        Task<bool> UserExistByIdAsync (int id);
        Task<bool> UserExistByIndexNumberAsync (int indexNumber);
        Task<bool> UserExistByEmailAsync (string email);
    }
}