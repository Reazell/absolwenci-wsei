using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IFieldDataRepository
    {
        Task AddAsync (FieldData fieldData);
        Task<FieldData> GetByQuestionIdAsync (int questionId, bool isTracking = true);
        Task<FieldData> GetByIdAsync (int id, bool isTracking = true);
        Task UpdateAsync (FieldData fieldData);
        Task DeleteAsync (FieldData fieldData);
    }
}