using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ISurveyReportRepository
    {
        Task AddAsync (SurveyReport surveyReport);
        Task<SurveyReport> GetBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task UpdateAsync (SurveyReport surveyReport);
        Task DeleteAsync (SurveyReport surveyReport);
    }
}