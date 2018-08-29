using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface ICareerOfficeService {
        Task<bool> ExistByIdAsync (int id);
        Task<bool> ExistByEmailAsync (string email);
    }
}