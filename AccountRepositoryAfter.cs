using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task AddAsync (Account account) {
            await _context.Accounts.AddAsync (account);
            await _context.SaveChangesAsync ();
        }

        public async Task<Account> GetByIdAsync (int id, bool isTracking = true) {
            Expression<Func<Account, bool>> searchExpression = (x => x.Id == id);
            IQueryable<Account> queryable = GetQueryable(isTracking);

            return await queryable.SingleOrDefaultAsync(searchExpression);
        }

        public async Task<Account> GetByEmailAsync (string email, bool isTracking = true) {
            Expression<Func<Account, bool>> searchExpression = (x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
            IQueryable<Account> queryable = GetQueryable(isTracking);

            return await queryable.SingleOrDefaultAsync(searchExpression);
        }

        public async Task<Account> GetByActivationKeyAsync (Guid activationKey, bool isTracking = true) {
            Expression<Func<Account, AccountActivation>> includeExpression = (x => x.AccountActivation);
            Expression<Func<Account, bool>> searchExpression = (x => x.AccountActivation.ActivationKey == activationKey && x.AccountActivation.Active == false);
            IQueryable<Account> queryable = GetQueryable(isTracking);

            return await queryable.Include(includeExpression).SingleOrDefaultAsync(searchExpression);
        }

        public async Task<Account> GetWithAccountRestoringPasswordAsync (int id, bool isTracking = true) {
            Expression<Func<Account, AccountRestoringPassword>> includeExpression = (x => x.AccountRestoringPassword);
            Expression<Func<Account, bool>> searchExpression = (x => x.Id == id);
            IQueryable<Account> queryable = GetQueryable(isTracking);

            return await queryable.Include(includeExpression).SingleOrDefaultAsync(searchExpression);
        }

        public async Task<Account> GetWithAccountRestoringPasswordByTokenAsync (Guid token, bool isTracking = true) {
            Expression<Func<Account, AccountRestoringPassword>> includeExpression = (x => x.AccountRestoringPassword);
            Expression<Func<Account, bool>> searchExpression = (x => x.AccountRestoringPassword.Token == token);
            IQueryable<Account> queryable = GetQueryable(isTracking);

            return await queryable.Include(includeExpression).SingleOrDefaultAsync(searchExpression);
        }

        public async Task<IEnumerable<Account>> GetAllAsync (bool isTracking = true) {
            IQueryable<Account> queryable = GetQueryable(isTracking);
            return await Task.FromResult(queryable.AsEnumerable());
        }

        private IQueryable<Account> GetQueryable(bool isTracking) {
            if(isTracking) {
                return _context.Accounts.AsTracking();
            } else {
                return _context.Accounts.AsNoTracking();
            }
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
