using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IRowChoiceOptionReportRepository
    {
        Task AddAsync (RowChoiceOptionReport rowChoiceOptionReport);
        Task GetBySurveyReportAsync (int rowReportId, bool isTracking = true);
        Task UpdateAsync (RowChoiceOptionReport rowChoiceOptionReport);
        Task DeleteAsync (RowChoiceOptionReport rowChoiceOptionReport);
    }
}