using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;
using CareerMonitoring.Infrastructure.Commands.Survey;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyTemplateService
    {
        Task<int> CreateSurveyAsync (SurveyToAdd command);
        Task<int> CreateAsync (string title, string description);
        Task<int> AddQuestionToSurveyAsync (int surveyTemplateId, int questionPosition, string content, string select, bool isRequired);
        Task<int> AddFieldDataToQuestionAsync (int questionTemplateId, string input, int minValue, int maxValue, string minLabel,
            string maxLabel);
        Task AddChoiceOptionsAsync (int fieldDataTemplateId, int optionPosition, bool value, string viewValue);
        Task AddRowAsync (int fieldDataTemplateId, int rowPosition, string input);
        Task<IEnumerable<SurveyTemplate>> GetAllAsync ();
        Task<SurveyTemplate> GetByIdAsync (int surveyTemplateId);
        Task<int> UpdateAsync (int surveyTemplateId, string title, string description);
        Task UpdateSurveyAsync (SurveyToUpdate command);
        Task DeleteAsync (int surveyTemplateId);
    }
}