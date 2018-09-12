using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IMultipleChoiceAnswerRepository
    {
        Task<MultipleChoiceAnswer> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<MultipleChoiceAnswer>> GetAllByQuestionIdAsync (int questionId, bool isTracking = true);
        Task AddAsync (MultipleChoiceAnswer multipleChoiceAnswer);
        Task UpdateAsync (MultipleChoiceAnswer multipleChoiceAnswer);
        Task DeleteAsync (MultipleChoiceAnswer multipleChoiceAnswer);
    }
}