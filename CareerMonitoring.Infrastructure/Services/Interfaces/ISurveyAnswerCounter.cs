using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyAnswerCounter
    {
        Task CountSurveyScores (int surveyId);
        Task CountSurveyAnswerScores (int surveyAnswerId);
    }
}