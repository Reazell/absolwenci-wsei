using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task AddAsync (Answer answer);
        Task<Answer> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<Answer>> GetAllAsync (bool isTracking = true);
        Task UpdateAsync (Answer answer);
        Task DeleteAsync (Answer answer);
    }
}