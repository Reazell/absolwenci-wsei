using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IUserRepository {
        Task AddAsync (User user);
        Task<User> GetByIdAsync (int id, bool isTracking = true);
        Task<User> GetByIndexNumberAsync (int indexNumber, bool isTracking = true);
        Task<User> GetByEmailAsync (string email, bool isTracking = true);
        Task<IEnumerable<User>> BrowseAsync ();
        Task UpdateAsync (User user);
        Task DeleteAsync (User user);
    }
}