using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces {
    public interface ISurveyEmailFactory {
//        Task SendSurveyEmailAsync (int surveyId);
        Task SendSurveyEmailToGroupAsync(int surveyId, int groupId);
        Task SendSurveyEmailToUnregisteredUsersAsync (int surveyId);
        string CalculateEmailHash(string input);
    }
}