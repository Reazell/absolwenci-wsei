using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ISurveyAnswerRepository
    {
        Task AddAsync (SurveyAnswer surveyAnswer);
        Task<SurveyAnswer> GetByIdWithQuestionsAsync (int id, bool isTracking = true);
        Task<SurveyAnswer> GetBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task<SurveyAnswer> GetByIdAsync(int id, bool isTracking = true);
        Task<SurveyAnswer> GetByTitleWithQuestionsAsync (string title, bool isTracking = true);
        Task<IEnumerable<SurveyAnswer>> GetAllWithQuestionsAsync (bool isTracking = true);
        Task<ICollection<SurveyAnswer>> GetAllBySurveyIdWithQuestionsAsync (int surveyId, bool isTracking = true);
        int CountAllSurveyAnswersBySurveyIdAsync(int surveyId);
        Task UpdateAsync (SurveyAnswer surveyAnswer);
        Task DeleteAsync (SurveyAnswer surveyAnswer);
    }
}