using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionAnswerRepository
    {
        Task AddAsync (QuestionAnswer questionAnswer);
        Task<ICollection<QuestionAnswer>> GetAllOpenQuestionAnswersBySurveyAnswerId (int surveyAnswerId);
        Task<IEnumerable<QuestionAnswer>> GetAllBySurveyAnswerIdInOrderAsync (int surveyAnswerId, bool isTracking = true);
        int CountAllQuestionAnswersByQuestionId(int surveyAnswerId, int id);
        Task<IEnumerable<QuestionAnswer>> GetAllBySurveyIdInOrderAsync (int surveyId, bool isTracking = true);
        Task<QuestionAnswer> GetByIdAsync(int id, bool isTracking = true);
        Task UpdateAsync (QuestionAnswer question);
        Task DeleteAsync (QuestionAnswer question);
    }
}