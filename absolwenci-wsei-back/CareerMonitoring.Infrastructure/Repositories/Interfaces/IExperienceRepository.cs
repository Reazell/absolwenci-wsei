using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> GetAllByUserIdAsync(int userId, bool isTracking = true);
    }
}