using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly CareerMonitoringContext _context;

        public GroupRepository (CareerMonitoringContext context) {
            _context = context;
        }
        
        public async Task CreateAsync(Group group, bool isTracking = true)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync ();
        }

        public async Task<bool> ExistsByNameAsync(string name, bool isTracking = true)
        {
            if (isTracking)
            {
                return _context.Groups.AsTracking().Any(x => x.Name == name);
            }
            return _context.Groups.AsNoTracking().Any(x => x.Name == name);
        }

        public async Task<Group> GetByIdAsync(int id, bool isTracking = true)
        {
            if (isTracking) {
                return await _context.Groups
                    .AsTracking ()
                    .Where (x => x.Id == id)
                    .Include(x => x.Users)
                    .ThenInclude(x=>x.User)
                    .SingleOrDefaultAsync();
            }
            return await _context.Groups
                .AsNoTracking ()
                .Where (x => x.Id == id)
                .Include(x => x.Users)
                .ThenInclude(x=>x.User)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Group>> GetAllAsync(bool isTracking = true)
        {
            if (isTracking){
                return await Task.FromResult (_context.Groups
                    .AsTracking ()
                    .Include(x => x.Users)
                    .ThenInclude(x=>x.User)
                    .AsEnumerable ());
            }
            return await Task.FromResult (_context.Groups
                .AsNoTracking ()
                .Include(x => x.Users)
                .ThenInclude(x=>x.User)
                .AsEnumerable ());
        }

        public async Task DeleteAsync(Group group)
        {
            _context.Groups.Remove (group);
            await _context.SaveChangesAsync ();
        }
    }
}