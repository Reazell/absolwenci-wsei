using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Commands.SurveyAnswer;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface ISurveyAnswerService {
        Task<int> CreateSurveyAnswerAsync (SurveyAnswerToAdd command);
        Task<int> CreateAsync (string surveyTitle, int surveyId);
        Task<int> AddQuestionAnswerToSurveyAnswerAsync (int surveyId, int surveyAnswerId, int questionPosition,
            string content, string select, bool isRequired);
        Task<int> AddFieldDataAnswerToQuestionAnswerAsync (int surveyId, int questionAnswerId, string input,
            string minLabel, string maxLabel);
        Task AddChoiceOptionsAnswerToFieldDataAnswerAsync (int surveyId, int fieldDataAnswerId, int optionPosition,
            bool value, string viewValue);
        Task AddChoiceOptionAnswerToRowAnswerAsync (int surveyId, int rowAnswerId, int optionPosition, bool value,
            string viewValue);
        Task<int> AddRowAnswerAsync (int fieldDataAnswerId, int rowPosition, string input);
    }
}