using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IAuthService {
        Task RegisterStudentAsync (string name, string surname, string email, int indexNumber, string phoneNumber, string password);
        Task<Account> LoginAsync (string email, string password);
    }
}