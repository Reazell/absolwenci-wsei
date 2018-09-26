using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyReportService
    {
        Task<int> CreateAsync(int surveyId, string surveyTitle);
        Task AddDataSetValues(int surveyId, SurveyReport surveyReport);
        Task<SurveyReport> GetByIdAsync(int id);
        Task UpdateAsync(int id);
        Task DeleteAsync(int id);
    }
}