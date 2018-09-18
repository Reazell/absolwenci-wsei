using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyScore;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface ISurveyScoreRepository {
        Task AddAsync (SurveyScore surveyScore);
        Task<SurveyScore> GetByIdAsync (int id, bool isTracking = true);
        Task UpdateAsync (SurveyScore surveyScore);
        Task DeleteAsync (SurveyScore surveyScore);
    }
}