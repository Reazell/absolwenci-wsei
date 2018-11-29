using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<Course>> GetAllByUserIdAsync(int userId, bool isTracking = true);
    }
}