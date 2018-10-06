using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IUnregisteredUserService {
        Task<bool> ExistByEmailAsync (string email);
        Task CreateAsync (string name, string surname, string email);
        // Task UpdateAsync (int id, string name, string surname, string email);
        // Task DeleteAsync (int id);
    }
}