using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly CareerMonitoringContext _context;

        public EducationRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task<Education> GetByIdAsync(int id, bool isTracking = true)
        {
            if (isTracking){
                return await _context.Educations
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Educations
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<Education>> GetAllByUserIdAsync(int userId, bool isTracking = true)
        {
            if (isTracking){
                return await Task.FromResult (_context.Educations
                    .AsTracking ()
                    .Where(x=>x.AccountId==userId));
            }
            return await Task.FromResult (_context.Educations
                .AsNoTracking ()
                .Where(x=>x.AccountId==userId));
        }
    }
}