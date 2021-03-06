using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
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

        public async Task<Account> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.Accounts
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Accounts
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Account> GetByMasterAsync(bool isTracking = true)
        {
            if (isTracking) {
                return await _context.Accounts
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Role == "master");
            }
            return await _context.Accounts
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Role == "master");
        }

        public async Task<Account> GetByEmailAsync (string email, bool isTracking = true)
        {
            Account account;
            if (isTracking) {
                account = await _context.Accounts
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Email.ToLowerInvariant () == email.ToLowerInvariant ());

                
                
                return account;
            }
            account =  await _context.Accounts
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Email.ToLowerInvariant () == email.ToLowerInvariant ());
            return account;
        }

        public async Task<Account> GetByActivationKeyAsync (Guid activationKey, bool isTracking = true) {
            if (isTracking) {
                return await _context.Accounts
                    .AsTracking ()
                    .Include (x => x.AccountActivation)
                    .SingleOrDefaultAsync (x =>
                        x.AccountActivation.ActivationKey == activationKey && x.AccountActivation.Active == false);
            }
            return await _context.Accounts
                .AsNoTracking ()
                .Include (x => x.AccountActivation)
                .SingleOrDefaultAsync (x =>
                    x.AccountActivation.ActivationKey == activationKey && x.AccountActivation.Active == false);
        }

        public async Task<Account> GetWithAccountRestoringPasswordAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.Accounts
                    .AsTracking ()
                    .Include (x => x.AccountRestoringPassword)
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Accounts
                .AsNoTracking ()
                .Include (x => x.AccountRestoringPassword)
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Account> GetWithAccountRestoringPasswordByTokenAsync (Guid token, bool isTracking = true) {
            if (isTracking) {
                return await _context.Accounts
                    .Include (x => x.AccountRestoringPassword)
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.AccountRestoringPassword.Token == token);
            }
            return await _context.Accounts
                .Include (x => x.AccountRestoringPassword)
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.AccountRestoringPassword.Token == token);
        }
        

        public async Task<IEnumerable<Account>> GetAllAsync (bool isTracking = true) {
            if (isTracking) {
                return await Task.FromResult (_context.Accounts
                    .AsTracking ()
                    .AsEnumerable ());
            }
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