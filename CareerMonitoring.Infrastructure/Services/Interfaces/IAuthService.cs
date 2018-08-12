using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IAuthService {
        Task RegisterAsync (string name, string surname, string email, int indexNumber, string password);
        Task<User> LoginAsync (string email, string password);
    }
}