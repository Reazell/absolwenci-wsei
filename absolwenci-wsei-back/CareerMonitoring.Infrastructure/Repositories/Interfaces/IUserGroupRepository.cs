using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IUserGroupRepository
    {
        
        Task AddUserAsync (UserGroup userGroup);
        Task RemoveUserAsync (UserGroup userGroup);
        Task<UserGroup> GetByIdsAsync (int userId,int groupId, bool isTracking = true);
    }
}