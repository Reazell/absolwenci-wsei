using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyReportService
    {
        Task<int> CreateAsync(int surveyId, string surveyTitle);
        Task<SurveyReport> GetReportAsync(int surveyId);
        Task<int> UpdateAsync(int surveyId, string surveyTitle);
    }
}