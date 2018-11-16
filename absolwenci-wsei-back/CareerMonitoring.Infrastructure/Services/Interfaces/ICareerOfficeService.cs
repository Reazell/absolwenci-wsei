using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface ICareerOfficeService {
        Task<bool> ExistByEmailAsync (string email);
    }
}