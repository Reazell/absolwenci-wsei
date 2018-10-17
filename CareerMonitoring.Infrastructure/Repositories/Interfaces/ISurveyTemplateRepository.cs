using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ISurveyTemplateRepository
    {
        Task AddAsync (SurveyTemplate surveyTemplate);
        Task<SurveyTemplate> GetByIdWithQuestionTemplatesAsync (int id, bool isTracking = true);
        Task<SurveyTemplate> GetByIdAsync(int id, bool isTracking = true);
        Task<SurveyTemplate> GetByTitleWithQuestionTemplatesAsync (string title, bool isTracking = true);
        Task<IEnumerable<SurveyTemplate>> GetAllWithQuestionTemplatesAsync (bool isTracking = true);
        Task<IEnumerable<SurveyTemplate>> GetAllWithQuestionTemplatesFieldDataTemplatesAndChoiceOptionTemplatesByTitleAsync (string title, bool isTracking = true);
        Task UpdateAsync (SurveyTemplate surveyTemplate);
        Task DeleteAsync (SurveyTemplate surveyTemplate);
    }
}