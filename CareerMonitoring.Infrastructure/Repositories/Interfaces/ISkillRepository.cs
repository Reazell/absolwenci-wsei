using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface ISkillRepository {
        Task AddAsync (Skill skill);
        Task<Skill> GetByIdAsync (int id, bool isTracking = true);
        Task<Skill> GetByNameAsync (string name, bool isTracking = true);
        Task<IEnumerable<Skill>> GetAllAsync (bool isTracking = true);
        Task UpdateAsync (Skill skill);
        Task DeleteAsync (Skill skill);
    }
}