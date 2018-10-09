using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionReportRepository
    {
        Task AddAsync (QuestionReport questionReport);
        Task<QuestionReport> GetByIdAsync (int id, bool isTracking = true);
        Task<QuestionReport> GetBySurveyReportAsync(int surveyReportId, string content, string select,
            bool isTracking = true);
        Task<QuestionReport> GetBySurveyReportContentAndPositionAsync(int surveyReportId, int questionPosition, string select);
        Task UpdateAsync (QuestionReport questionReport);
        Task DeleteAsync (QuestionReport questionReport);
    }
}