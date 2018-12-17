using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IAuthService {
        Task RegisterCareerOfficeAsync (string name, string surname, string email, string phoneNumber, string password);
        Task RegisterMasterAsync (string name, string surname, string email, string phoneNumber, string password);
        Task<Account> LoginAsync (string email, string password);
    }
}