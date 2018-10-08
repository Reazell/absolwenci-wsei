using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces {
    public interface ISurveyEmailFactory {
        Task SendSurveyEmailAsync (int surveyId);
        Task SendSurveyEmailToUnregisteredUsersAsync (int surveyId);
    }
}