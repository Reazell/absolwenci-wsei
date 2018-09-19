using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IRowRepository
    {
        Task AddAsync (Row row);
        Task<IEnumerable<Row>> GetAllByFieldDataIdInOrderAsync (int fieldDataId, bool isTracking = true);
        Task<Row> GetByFieldDataIdAsync (int fieldDataId, int rowPosition, bool isTracking = true);
        Task UpdateAsync (Row row);
        Task DeleteAsync (Row row);
    }
}