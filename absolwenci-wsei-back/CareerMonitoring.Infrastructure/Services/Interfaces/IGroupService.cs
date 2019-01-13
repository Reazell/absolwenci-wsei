using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface IGroupService
    {
        Task<int> CreateAsync(string name);
        Task AddUserAsync(int groupId, int userId);
        Task RemoveUserAsync(int groupId, int userId);
        Task<Group> GetByIdAsync(int id);
        Task<IEnumerable<Group>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}