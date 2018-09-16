using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task AddAsync (Question question);
        Task<IEnumerable<Question>> GetAllBySurveyIdInOrderAsync (int surveyId, bool isTracking = true);
        Task<Question> GetByIdAsync(int id, bool isTracking = true);
        Task UpdateAsync (Question question);
        Task DeleteAsync (Question question);
    }
}