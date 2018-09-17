using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyScore;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IScoreRepository {
        Task AddAsync (SurveyScore surveyScore);
        Task<SurveyScore> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<QuestionScore>> GetAllBySurveyScoreIdInOrderAsync (int surveyId, bool isTracking = true);
        Task UpdateAsync (SurveyScore surveyScore);
    }
}