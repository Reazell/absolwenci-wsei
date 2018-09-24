using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyReportService
    {
        Task<int> CreateAsync(int surveyId, string surveyTitle);
        Task<int> AddQuestionReport(int surveyReportId, int surveyAnswerId, int questionAnswerId,
            string content, string select, ICollection<string> labels);

        Task AddDataSetToQuestionReportAsync(int questionReportId);
        Task GetByIdAsync(int id);
        Task UpdateAsync(int id);
        Task DeleteAsync(int id);
    }
}