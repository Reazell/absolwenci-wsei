using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ISingleChoiceRepository
    {
        Task<SingleChoice> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<SingleChoice>> GetBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task AddAsync (SingleChoice singleChoice);
        Task UpdateAsync (SingleChoice singleChoice);
        Task DeleteAsync (SingleChoice singleChoice);
    }
}