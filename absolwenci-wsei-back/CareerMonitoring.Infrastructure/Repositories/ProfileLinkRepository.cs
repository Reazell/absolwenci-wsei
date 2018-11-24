using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class ProfileLinkRepository : IProfileLinkRepository
    {
        private readonly CareerMonitoringContext _context;

        public ProfileLinkRepository (CareerMonitoringContext context) {
            _context = context;
        }
        
        public async Task<IEnumerable<ProfileLink>> GetAllByUserIdAsync(int userId, bool isTracking = true)
        {
            if (isTracking){
                return await Task.FromResult (_context.ProfileLinks
                    .AsTracking ()
                    .Where(x=>x.AccountId==userId));
            }
            return await Task.FromResult (_context.ProfileLinks
                .AsNoTracking ()
                .Where(x=>x.AccountId==userId));
        }
    }
}