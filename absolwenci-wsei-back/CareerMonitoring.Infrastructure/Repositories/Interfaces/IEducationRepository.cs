using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        Task<Education> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<Education>> GetAllByUserIdAsync(int userId, bool isTracking = true);
    }
}