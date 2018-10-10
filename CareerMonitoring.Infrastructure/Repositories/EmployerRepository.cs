using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class EmployerRepository : IEmployerRepository {
        private readonly CareerMonitoringContext _context;

        public EmployerRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (Employer employer) {
            await _context.Employers.AddAsync (employer);
            await _context.SaveChangesAsync ();
        }

        public async Task<Employer> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking){
                return await _context.Employers
                .AsTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Employers
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Employer> GetByEmailAsync (string email, bool isTracking = true) {
            if (isTracking){
                return await _context.Employers
                    .AsTracking()
                    .SingleOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
            }
            return await _context.Employers
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
        }

        public async Task<IEnumerable<Employer>> GetAllAsync (bool isTracking = true) {
            if (isTracking){
                return await Task.FromResult (_context.Employers
                    .AsTracking ()
                    .AsEnumerable ());
            }
            return await Task.FromResult (_context.Employers
                .AsNoTracking ()
                .AsEnumerable ());
        }

        public async Task UpdateAsync (Employer employer) {
            _context.Employers.Update (employer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (Employer employer) {
            _context.Employers.Remove (employer);
            await _context.SaveChangesAsync ();
        }
    }
}