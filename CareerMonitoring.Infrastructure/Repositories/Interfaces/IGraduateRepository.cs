using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IGraduateRepository {
        Task AddAsync (Graduate graduate);
        Task<Graduate> GetByIdAsync (int id, bool isTracking = true);
        Task<Graduate> GetByEmailAsync (string email, bool isTracking = true);
    }
}