using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionTemplateRepository
    {
        Task AddAsync (QuestionTemplate questionTemplate);
        Task<IEnumerable<QuestionTemplate>> GetAllBySurveyTemplateIdInOrderAsync (int surveyTemplateId, bool isTracking = true);
        Task<QuestionTemplate> GetByIdAsync(int id, bool isTracking = true);
        Task<QuestionTemplate> GetByContentAsync (int surveyTemplateId, string content, bool isTracking = true);
        Task<QuestionTemplate> GetBySurveyTemplateIdAsync (int surveyTemplateId, int questionPosition, bool isTracking = true);
        Task UpdateAsync (QuestionTemplate questionTemplate);
        Task DeleteAsync (QuestionTemplate questionTemplate);
    }
}