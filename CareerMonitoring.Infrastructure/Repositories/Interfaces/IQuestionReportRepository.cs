using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionReportRepository
    {
        Task AddAsync (QuestionReport questionReport);
        Task<QuestionReport> GetBySurveyReportAsync (int surveyReportId, int id, bool isTracking = true);
        Task UpdateAsync (QuestionReport questionReport);
        Task DeleteAsync (QuestionReport questionReport);
    }
}