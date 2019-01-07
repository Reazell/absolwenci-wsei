using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class MasterRepository:IMasterRepository
    {
        private readonly CareerMonitoringContext _context;

        public MasterRepository (CareerMonitoringContext context) {
            _context = context;
        }
        
        public async Task AddAsync(Master master)
        {
            await _context.Masters.AddAsync (master);
            await _context.SaveChangesAsync ();
        }

        public async Task<Master> GetByIdAsync(int id, bool isTracking = true)
        {
            if (isTracking) {
                return await _context.Masters
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Masters
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Master> GetByEmailAsync(string email, bool isTracking = true)
        {
            if (isTracking) {
                return await _context.Masters
                    .AsTracking()
                    .SingleOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
            }
            return await _context.Masters.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
        }

        public async Task<IEnumerable<Master>> GetAllAsync (bool isTracking = true) {
            if (isTracking){
                return await Task.FromResult (_context.Masters
                    .AsTracking ()
                    .AsEnumerable ());
            }
            return await Task.FromResult (_context.Masters
                .AsNoTracking ()
                .AsEnumerable ());
        }

        public async Task UpdateAsync(Master master)
        {
            _context.Masters.Update(master);
            await _context.SaveChangesAsync();
        }
    }
}