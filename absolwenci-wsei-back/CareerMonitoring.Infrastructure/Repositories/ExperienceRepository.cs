using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly CareerMonitoringContext _context;

        public ExperienceRepository (CareerMonitoringContext context) {
            _context = context;
        }
        
        public async Task<IEnumerable<Experience>> GetAllByUserIdAsync(int userId, bool isTracking = true)
        {
            if (isTracking){
                return await Task.FromResult (_context.Experiences
                    .AsTracking ()
                    .Where(x=>x.AccountId==userId));
            }
            return await Task.FromResult (_context.Experiences
                .AsNoTracking ()
                .Where(x=>x.AccountId==userId));
        }
    }
}