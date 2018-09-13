using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.DTO;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface ISurveyService {
        Task<SurveyDto> GetByIdAsync (int id);
        Task<SurveyDto> GetByTitleAsync (string title);
        Task<IEnumerable<SurveyDto>> GetAllAsync ();
        Task CreateAsync (string title);
        Task AddLinearScaleQuestionAsync (int surveyId, string content, int minValue, int maxValue, string minLabel, string maxLabel);
        Task AddSingleChoiceQuestionAsync (int surveyId, string content, ICollection<string> answersOptions);
        Task AddMultipleChoiceQuestionAsync (int surveyId, string content, ICollection<string> answersOptions);
        Task AddOpenQuestionAsync (int surveyId, string content);
        Task AddSingleGridQuestionAsync (int surveyId, string content, ICollection<string> rows, ICollection<string> cols);
        Task AddMultipleGridQuestionAsync (int surveyId, string content, ICollection<string> rows, ICollection<string> cols);
        Task DeleteAsync (int id);
        Task UpdateAsync (int id);
    }
}