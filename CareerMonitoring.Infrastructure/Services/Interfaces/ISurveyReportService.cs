using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyReportService
    {
        Task<int> CreateAsync(int surveyId, string surveyTitle);

        Task<SurveyReport> GetReportAsync(int surveyId);
        // Task AddDataSetValues(int surveyId, SurveyReport surveyReport);
        // Task<SurveyReport> GetByIdAsync(int id);
        Task<int> UpdateAsync(int surveyId, string surveyTitle);
        // Task DeleteAsync(int id);
    }
}