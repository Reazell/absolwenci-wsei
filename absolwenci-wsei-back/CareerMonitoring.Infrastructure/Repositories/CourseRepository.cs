using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CareerMonitoringContext _context;

        public CourseRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task<Course> GetByIdAsync(int id, bool isTracking = true)
        {
            if (isTracking){
                return await _context.Courses
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Courses
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<Course>> GetAllByUserIdAsync(int userId, bool isTracking = true)
        {
            if (isTracking){
                return await Task.FromResult (_context.Courses
                    .AsTracking ()
                    .Where(x=>x.AccountId==userId));
            }
            return await Task.FromResult (_context.Courses
                .AsNoTracking ()
                .Where(x=>x.AccountId==userId));
        }
    }
}