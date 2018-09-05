using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.DTO;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyService
    {
        Task<SurveyDto> GetByIdAsync (int id, bool isTracking = true);
        Task<SurveyDto> GetByTitleAsync (string title, bool isTracking = true);
        Task<IEnumerable<SurveyDto>> GetAllAsync (bool isTracking = true);
        Task CreateAsync (string title);
        Task AddLinearScaleQuestionAsync (int surveyId, string content, int minValue, int maxValue, string minLabel, string maxLabel);
        Task AddSingleChoiceQuestionAsync (int surveyId, string content);
        Task AddMultipleChoiceQuestionAsync (int surveyId, string content);
        Task AddOpenQuestionAsync (int surveyId, string content);
        Task DeleteAsync ();
        Task UpdateAsync ();
    }
}