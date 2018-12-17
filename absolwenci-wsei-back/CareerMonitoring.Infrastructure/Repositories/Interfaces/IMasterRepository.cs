using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IMasterRepository
    {
        Task AddAsync (Master master);
        Task<Master> GetByIdAsync (int id, bool isTracking = true);
        Task<Master> GetByEmailAsync (string email, bool isTracking = true);
        Task UpdateAsync (Master master);
    }
}