using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IStudentService {
        Task<bool> ExistByEmailAsync (string email);
    }
}