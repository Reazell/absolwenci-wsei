using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IRowAnswerRepository
    {
        Task AddAsync (RowAnswer rowAnswer);
        Task<IEnumerable<RowAnswer>> GetAllByFieldDataIdInOrderAsync (int fieldDataAnswerId, bool isTracking = true);
        Task<RowAnswer> GetByIdAsync(int id, bool isTracking = true);
        Task UpdateAsync (RowAnswer rowAnswer);
        Task DeleteAsync (RowAnswer rowAnswer);
    }
}