using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IChoiceOptionTemplateRepository
    {
        Task AddAsync (ChoiceOptionTemplate choiceOptionTemplate);
        Task<ChoiceOptionTemplate> GetByIdAsync (int id);
        Task<IEnumerable<ChoiceOptionTemplate>> GetAllByFieldDataIdInOrderAsync (int fieldDataTemplateId, bool isTracking = true);
        Task<ChoiceOptionTemplate> GetByFieldDataIdAsync (int fieldDataTemplateId, int optionPosition, bool isTracking = true);
        Task UpdateAsync (ChoiceOptionTemplate choiceOptionTemplate);
        Task DeleteAsync (ChoiceOptionTemplate choiceOptionTemplate);
    }
}