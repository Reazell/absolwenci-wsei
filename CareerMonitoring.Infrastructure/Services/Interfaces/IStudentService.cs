using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IStudentService {
        Task<bool> ExistByIdAsync (int id);
        Task<bool> ExistByIndexNumberAsync (int indexNumber);
        Task<bool> ExistByEmailAsync (string email);
    }
}