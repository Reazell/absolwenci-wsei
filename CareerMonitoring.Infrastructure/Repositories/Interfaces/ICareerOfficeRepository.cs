using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface ICareerOfficeRepository {
        Task AddAsync (CareerOffice careerOffice);
        Task<CareerOffice> GetByIdAsync (int id, bool isTracking = true);
        Task<CareerOffice> GetByEmailAsync (string email, bool isTracking = true);
    }
}