using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IRowChoiceOptionAnswerRepository
    {
        Task AddAsync (RowChoiceOptionAnswer rowChoiceOptionAnswer);
        Task<IEnumerable<RowChoiceOptionAnswer>> GetAllByFieldDataIdInOrderAsync (int rowAnswerId, bool isTracking = true);
        Task UpdateAsync (RowChoiceOptionAnswer rowChoiceOptionAnswer);
        Task DeleteAsync (RowChoiceOptionAnswer rowChoiceOptionAnswer);
    }
}