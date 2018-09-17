using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IChoiceOptionAnswerRepository
    {
        Task AddAsync (ChoiceOptionAnswer choiceOptionAnswer);
        Task<IEnumerable<ChoiceOptionAnswer>> GetAllByFieldDataIdInOrderAsync (int fieldDataAnswerId, bool isTracking = true);
        Task UpdateAsync (ChoiceOptionAnswer choiceOptionAnswer);
        Task DeleteAsync (ChoiceOptionAnswer choiceOptionAnswer);
    }
}