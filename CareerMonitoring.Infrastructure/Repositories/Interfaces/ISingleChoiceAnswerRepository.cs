using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ISingleChoiceAnswerRepository
    {
        Task<SingleChoiceAnswer> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<SingleChoiceAnswer>> GetAllByQuestionIdAsync (int questionId, bool isTracking = true);
        Task AddAsync (SingleChoiceAnswer singleChoiceAnswer);
        Task UpdateAsync (SingleChoiceAnswer singleChoiceAnswer);
        Task DeleteAsync (SingleChoiceAnswer singleChoiceAnswer);
    }
}