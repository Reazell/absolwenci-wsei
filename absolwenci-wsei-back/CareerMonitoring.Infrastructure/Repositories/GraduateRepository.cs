using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class GraduateRepository : IGraduateRepository {
        private readonly CareerMonitoringContext _context;

        public GraduateRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (Graduate graduate) {
            await _context.Graduates.AddAsync (graduate);
            await _context.SaveChangesAsync ();
        }

        public async Task<Graduate> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking)
                return await _context.Graduates.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.Graduates.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Graduate> GetByEmailAsync (string email, bool isTracking = true) {
            if (isTracking)
                return await _context.Graduates.AsTracking()
                    .SingleOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
            return await _context.Graduates.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
        }

        public async Task<IEnumerable<Graduate>> GetAllAsync (bool isTracking = true) {
            if (isTracking)
                return await Task.FromResult (_context.Graduates.AsTracking ().AsEnumerable ());
            return await Task.FromResult (_context.Graduates.AsNoTracking ().AsEnumerable ());
        }

        public async Task UpdateAsync (Graduate graduate) {
            _context.Graduates.Update (graduate);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (Graduate graduate) {
            _context.Graduates.Remove (graduate);
            await _context.SaveChangesAsync ();
        }
    }
}