using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyService
    {
        Task CreateAsync (string title);
        Task AddLinearScaleQuestionAsync (int surveyId, string content, int minValue, int maxValue, string minLabel, string maxLabel);
        Task AddSingleChoiceQuestionAsync (int surveyId, string content);
        Task AddMultipleChoiceQuestionAsync (int surveyId, string content);
        Task AddAnswerAsync ();
        Task DeleteAsync ();
        Task UpdateAsync ();
    }
}