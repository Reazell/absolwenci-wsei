using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface ISkillRepository {
        Task<Skill> GetByIdAsync (int id, bool isTracking = true);
    }
}