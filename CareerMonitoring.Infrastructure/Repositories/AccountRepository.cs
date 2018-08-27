using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class AccountRepository : IAccountRepository {
        private readonly CareerMonitoringContext _context;

        public AccountRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (Account account) {
            await _context.Accounts.AddAsync (account);
            await _context.SaveChangesAsync ();
        }

        public async Task<Account> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking)
                return await _context.Accounts.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.Accounts.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Account> GetByEmailAsync (string email, bool isTracking = true) {
            if (isTracking)
                return await _context.Accounts.AsTracking ().SingleOrDefaultAsync (x => x.Email == email);
            return await _context.Accounts.AsNoTracking ().SingleOrDefaultAsync (x => x.Email == email);
        }

        public async Task<Account> GetByActivationKeyAsync (Guid activationKey, bool isTracking = true) {
            if (isTracking)
                return await _context.Accounts.AsTracking ().Include (x => x.AccountActivation).
            SingleOrDefaultAsync (x => x.AccountActivation.ActivationKey == activationKey && x.AccountActivation.Active == false);
            return await _context.Accounts.AsNoTracking ().Include (x => x.AccountActivation).
            SingleOrDefaultAsync (x => x.AccountActivation.ActivationKey == activationKey && x.AccountActivation.Active == false);
        }

        public async Task<IEnumerable<Account>> GetAllAsync (bool isTracking = true) {
            if (isTracking)
                return await Task.FromResult (_context.Accounts.AsTracking ().AsEnumerable ());
            return await Task.FromResult (_context.Accounts.AsNoTracking ().AsEnumerable ());
        }

        public async Task UpdateAsync (Account account) {
            _context.Accounts.Update (account);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (Account account) {
            _context.Accounts.Remove (account);
            await _context.SaveChangesAsync ();
        }
    }
}