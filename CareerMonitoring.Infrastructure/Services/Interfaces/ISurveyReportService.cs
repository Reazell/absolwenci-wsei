using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyReportService
    {
        Task CreateAsync (int surveyId, string surveyTitle, int answersNumber, int surveyRecepientsNumber);
        Task AddQuestionReportAsync (int questionPosition, string content, string select, int answersNumber, string minLabel, string maxLabel);
        Task AddChoiceOptionReportasync (int optionPosition, int optionCounter, string viewValue);
    }
}