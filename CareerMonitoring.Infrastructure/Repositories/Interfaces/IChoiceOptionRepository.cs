using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IChoiceOptionRepository
    {
        Task AddAsync (ChoiceOption choiceOption);
        Task<ChoiceOption> GetByIdAsync (int id);
        Task<IEnumerable<ChoiceOption>> GetAllByFieldDataIdInOrderAsync (int fieldDataId, bool isTracking = true);
        Task<ChoiceOption> GetByFieldDataIdAsync (int fieldDataId, int optionPosition, bool isTracking = true);
        Task UpdateAsync (ChoiceOption choiceOption);
        Task DeleteAsync (ChoiceOption choiceOption);
    }
}