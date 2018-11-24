using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<Certificate>> GetAllByUserIdAsync(int userId, bool isTracking = true);
    }
}