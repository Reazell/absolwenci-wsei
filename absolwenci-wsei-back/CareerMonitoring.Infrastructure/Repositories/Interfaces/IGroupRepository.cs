using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task CreateAsync(Group group, bool isTracking = true);
        Task<Group> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<Group>> GetAllAsync(bool isTracking = true);
        Task DeleteAsync(Group group);
    }
}