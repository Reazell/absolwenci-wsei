using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface ILanguageRepository {
        Task AddAsync (Language language);
        Task<Language> GetByIdAsync (int id, bool isTracking = true);
        Task<Language> GetByNameAsync (string name, bool isTracking = true);
        Task<IEnumerable<Language>> GetAllAsync (bool isTracking = true);
        Task<IEnumerable<Language>> GetAllByUserIdAsync(int userId, bool isTracking = true);
        Task UpdateAsync (Language language);
        Task DeleteAsync (Language language);
    }
}