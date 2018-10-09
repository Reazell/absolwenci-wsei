using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IUnregisteredUserRepository {
        Task AddAsync (UnregisteredUser unregisteredUser);
        Task AddAllAsync (IEnumerable<UnregisteredUser> unregisteredUsers);
        Task<UnregisteredUser> GetByIdAsync (int id, bool isTracking = true);
        Task<UnregisteredUser> GetByEmailAsync (string email, bool isTracking = true);
        Task<IEnumerable<UnregisteredUser>> GetAllAsync (bool isTracking = true);
        Task UpdateAsync (UnregisteredUser unregisteredUser);
        Task DeleteAsync (UnregisteredUser unregisteredUser);
    }
}