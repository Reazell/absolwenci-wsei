using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IUnregisteredUserRepository {
        Task AddAllAsync (IEnumerable<UnregisteredUser> importData);
        Task<IEnumerable<UnregisteredUser>> GetAllAsync (bool isTracking = true);
    }
}