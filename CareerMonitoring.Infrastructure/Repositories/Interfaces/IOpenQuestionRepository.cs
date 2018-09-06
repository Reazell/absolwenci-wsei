using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IOpenQuestionRepository
    {
        Task<OpenQuestion> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<OpenQuestion>> GetBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task AddAsync (OpenQuestion openQuestion);
        Task UpdateAsync (OpenQuestion openQuestion);
        Task DeleteAsync (OpenQuestion openQuestion);
    }
}