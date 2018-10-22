using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task AddAsync (Question question);
        Task<Question> GetByIdAsync(int id, bool isTracking = true);
    }
}