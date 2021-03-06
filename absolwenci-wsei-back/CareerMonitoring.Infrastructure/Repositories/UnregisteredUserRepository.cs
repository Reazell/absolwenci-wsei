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

        public async Task AddAsync (UnregisteredUser unregisteredUser) {
            await _context.UnregisteredUsers.AddAsync (unregisteredUser);
            await _context.SaveChangesAsync ();
        }

        public async Task AddAllAsync (IEnumerable<UnregisteredUser> unregisteredUsers) {
            await _context.UnregisteredUsers.AddRangeAsync (unregisteredUsers);
            await _context.SaveChangesAsync ();
        }

        public async Task<UnregisteredUser> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking){
                return await _context.UnregisteredUsers
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.UnregisteredUsers
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<UnregisteredUser> GetByEmailAsync (string email, bool isTracking = true) {
            if (isTracking){
                return await _context.UnregisteredUsers
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Email.ToLowerInvariant () == email.ToLowerInvariant ());
            }
            return await _context.UnregisteredUsers
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Email.ToLowerInvariant () == email.ToLowerInvariant ());
        }

        public async Task<IEnumerable<UnregisteredUser>> GetAllAsync (bool isTracking = true) {
            if (isTracking){
                return await Task.FromResult (_context.UnregisteredUsers
                    .AsTracking ()
                    .AsEnumerable ());
            }
            return await Task.FromResult (_context.UnregisteredUsers
                .AsNoTracking ()
                .AsEnumerable ());
        }

        public async Task UpdateAsync (UnregisteredUser unregisteredUser) {
            _context.UnregisteredUsers.Update (unregisteredUser);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (UnregisteredUser unregisteredUser) {
            _context.UnregisteredUsers.Remove (unregisteredUser);
            await _context.SaveChangesAsync ();
        }

    }
}