using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class UnregisteredUserRepository : IUnregisteredUserRepository {
        private readonly CareerMonitoringContext _context;

        public UnregisteredUserRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAllAsync (IEnumerable<UnregisteredUser> unregisteredUser) {
            await _context.UnregisteredUsers.AddRangeAsync (unregisteredUser);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<UnregisteredUser>> GetAllAsync (bool isTracking = true) {
            if (isTracking)
                return await Task.FromResult (_context.UnregisteredUsers.AsTracking ().AsEnumerable ());
            return await Task.FromResult (_context.UnregisteredUsers.AsNoTracking ().AsEnumerable ());
        }

    }
}