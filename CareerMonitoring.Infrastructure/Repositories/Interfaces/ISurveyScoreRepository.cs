using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Score;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface ISurveyScoreRepository {
        Task AddAsync (SurveyScore surveyScore);
        Task<SurveyScore> GetByIdAsync (int id, bool isTracking = true);
        Task<SurveyScore> GetBySurveyIdAsync (int id, bool isTracking = true);
        Task<SurveyScore> GetByTitleAsync (string title, bool isTracking = true);
        Task<SurveyScore> GetWithAllScoresByIdAsync (int id, bool isTracking = true);
        Task<SurveyScore> GetWithAllScoresBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task UpdateAsync (SurveyScore surveyScore);
        Task DeleteAsync (SurveyScore surveyScore);
    }
}