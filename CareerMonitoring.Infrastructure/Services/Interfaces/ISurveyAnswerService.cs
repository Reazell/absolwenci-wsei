using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyAnswerService
    {
        Task<int> CreateAsync(string surveyTitle);
        Task<int> AddQuestionAnswerToSurveyAnswerAsync (int surveyAnswerId, int questionPosition, string content, string select);
        Task<int> AddFieldDataAnswerToQuestionAnswerAsync (int questionAnswerId, string input, int minValue, int maxValue, string minLabel, string maxLabel);
        Task AddChoiceOptionsAnswerAsync (int fieldDataAnswerId, int optionPosition, bool value, string viewValue);
        Task AddRowAnswerAsync (int fieldDataAnswerId, int rowPosition, string input);
        Task<IEnumerable<SurveyAnswer>> GetAllAsync();
        Task<SurveyAnswer> GetBySurveyIdAsync(int surveyId);
        Task<SurveyAnswer> GetBySurveyTitleAsync(string surveyTitle);
        Task DeleteAsync(int surveyAnswerId);
    }
}