using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IChoiceOptionReportRepository
    {
        Task AddAsync (ChoiceOptionReport choiceOptionReport);
        Task<IEnumerable<ChoiceOptionReport>> GetByQuestionReportAsync (int questionReportId, bool isTracking = true);
        Task UpdateAsync (ChoiceOptionReport choiceOptionReport);
        Task DeleteAsync (ChoiceOptionReport choiceOptionReport);
    }
}