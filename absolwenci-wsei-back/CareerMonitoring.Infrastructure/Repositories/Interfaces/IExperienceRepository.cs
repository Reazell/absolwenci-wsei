using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IExperienceRepository
    {
        Task<Experience> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<Experience>> GetAllByUserIdAsync(int userId, bool isTracking = true);
    }
}