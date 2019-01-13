using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly CareerMonitoringContext _context;

        public UserGroupRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddUserAsync(UserGroup userGroup)
        {
            await _context.UserGroups.AddAsync(userGroup);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserAsync(UserGroup userGroup)
        {
            _context.UserGroups.Remove(userGroup);
            await _context.SaveChangesAsync();
        }

        public async Task<UserGroup> GetByIdsAsync(int userId, int groupId, bool isTracking = true)
        {
            if (isTracking){
                
                return await _context.UserGroups
                    .AsTracking()
                    .Where(x=>x.GroupId==groupId)
                    .Where(x=>x.UserId==userId)
                    .SingleOrDefaultAsync();
            }
            
            return await _context.UserGroups
                .AsNoTracking()
                .Where(x=>x.GroupId==groupId)
                .Where(x=>x.UserId==userId)
                .SingleOrDefaultAsync();
        }
    }
}