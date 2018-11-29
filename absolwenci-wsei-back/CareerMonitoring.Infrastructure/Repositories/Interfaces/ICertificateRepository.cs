using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ICertificateRepository
    {
        Task<Certificate> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<Certificate>> GetAllByUserIdAsync(int userId, bool isTracking = true);
    }
}