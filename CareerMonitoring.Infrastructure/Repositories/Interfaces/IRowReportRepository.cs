using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IRowReportRepository
    {
        Task AddAsync (RowReport rowReport);
        Task<RowReport> GetByQuestionReportAsync (int questionReportId, bool isTracking = true);
        Task UpdateAsync (RowReport rowReport);
        Task DeleteAsync (RowReport rowReport);
    }
}