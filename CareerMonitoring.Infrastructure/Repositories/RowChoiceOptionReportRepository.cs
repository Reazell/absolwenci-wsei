using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class RowChoiceOptionReportRepository : IRowChoiceOptionReportRepository
    {
        public Task AddAsync(RowChoiceOptionReport rowChoiceOptionReport)
        {
            throw new System.NotImplementedException();
        }

        public Task GetBySurveyReportAsync(int rowReportId, bool isTracking = true)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(RowChoiceOptionReport rowChoiceOptionReport)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(RowChoiceOptionReport rowChoiceOptionReport)
        {
            throw new System.NotImplementedException();
        }
    }
}