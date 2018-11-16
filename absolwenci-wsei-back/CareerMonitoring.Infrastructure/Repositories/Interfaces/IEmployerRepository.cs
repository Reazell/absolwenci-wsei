using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IEmployerRepository {
        Task AddAsync (Employer employer);
        Task<Employer> GetByIdAsync (int id, bool isTracking = true);
        Task<Employer> GetByEmailAsync (string email, bool isTracking = true);
        Task UpdateAsync (Employer employer);
    }
}