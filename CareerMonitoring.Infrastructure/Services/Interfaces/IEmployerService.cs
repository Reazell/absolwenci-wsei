using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IEmployerService {
        Task<bool> ExistByIdAsync (int id);
        Task<bool> ExistByEmailAsync (string email);
    }
}