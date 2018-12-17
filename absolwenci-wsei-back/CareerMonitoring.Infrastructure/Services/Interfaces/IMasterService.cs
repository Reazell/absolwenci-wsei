using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface IMasterService{
        Task<bool> ExistByEmailAsync (string email);
    }
}