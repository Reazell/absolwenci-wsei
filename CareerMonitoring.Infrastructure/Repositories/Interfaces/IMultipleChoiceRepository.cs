using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IMultipleChoiceRepository
    {
        Task<MultipleChoice> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<MultipleChoice>> GetBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task AddAsync (MultipleChoice multipleChoice);
        Task UpdateAsync (MultipleChoice multipleChoice);
        Task DeleteAsync (MultipleChoice multipleChoice);
    }
}