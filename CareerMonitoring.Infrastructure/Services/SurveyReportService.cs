using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Repositories;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services
{
    public class SurveyReportService : ISurveyReportService
    {
        private readonly SurveyReportRepository _surveyReportRepository;

        public SurveyReportService (SurveyReportRepository surveyReportRepository)
        {
            _surveyReportRepository = surveyReportRepository;
        }
        public async Task CreateAsync(int surveyId, string surveyTitle, int answersNumber, int surveyRecepientsNumber)
        {
            //var surveyReport = 
        }

        public async Task AddQuestionReportAsync (int questionPosition, string content, string select, int answersNumber, string minLabel, string maxLabel)
        {

        }
        public async Task AddChoiceOptionReportasync (int optionPosition, int optionCounter, string viewValue)
        {

        }
    }
}