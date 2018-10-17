using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IRowTemplateRepository
    {
        Task AddAsync (RowTemplate rowTemplate);
        Task<RowTemplate> GetByIdAsync (int id);
        Task<IEnumerable<RowTemplate>> GetAllByFieldDataIdInOrderAsync (int fieldDataTemplateId, bool isTracking = true);
        Task<RowTemplate> GetByFieldDataIdAsync (int fieldDataTemplateId, int rowPosition, bool isTracking = true);
        Task UpdateAsync (RowTemplate rowTemplate);
        Task DeleteAsync (RowTemplate rowTemplate);
    }
}