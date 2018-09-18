using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyScore;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IQuestionScoreRepository {
        Task<IEnumerable<QuestionScore>> GetAllBySurveyScoreIdInOrderAsync (int surveyId, bool isTracking = true);
    }
}