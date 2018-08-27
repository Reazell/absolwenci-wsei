using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class UserRepository : IUserRepository {
        private readonly CareerMonitoringContext _context;

        public UserRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (User user) {
            await _context.Users.AddAsync (user);
            await _context.SaveChangesAsync ();
        }

        public async Task<User> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking)
                return await _context.Users.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.Users.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);
        }
        public async Task<User> GetByActivationKeyAsync (Guid activationKey, bool isTracking = true)
        {
            if (isTracking)
                return await _context.Users.AsTracking ().SingleOrDefaultAsync (x => x.ActivationKey == activationKey);
            return await _context.Users.AsNoTracking ().SingleOrDefaultAsync (x => x.ActivationKey == activationKey);
        }

        public async Task<User> GetByIndexNumberAsync (int indexNumber, bool isTracking = true) {
            if (isTracking)
                return await _context.Users.AsTracking ().SingleOrDefaultAsync (x => x.IndexNumber == indexNumber);
            return await _context.Users.AsNoTracking ().SingleOrDefaultAsync (x => x.IndexNumber == indexNumber);
        }

        public async Task<User> GetByEmailAsync (string email, bool isTracking = true) {
            if (isTracking)
                return await _context.Users.AsTracking ().SingleOrDefaultAsync (x => x.Email == email);
            return await _context.Users.AsNoTracking ().SingleOrDefaultAsync (x => x.Email == email);
        }

        public Task<IEnumerable<User>> BrowseAsync () {
            throw new System.NotImplementedException ();
        }

        public async Task UpdateAsync (User user) {
            _context.Users.Update (user);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (User user) {
            _context.Users.Remove (user);
            await _context.SaveChangesAsync ();
        }
    }
}