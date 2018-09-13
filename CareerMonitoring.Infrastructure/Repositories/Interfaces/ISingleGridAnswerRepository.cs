using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ISingleGridAnswerRepository
    {
        Task<SingleGridAnswer> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<SingleGridAnswer>> GetAllByQuestionIdAsync (int questionId, bool isTracking = true);
        Task AddAsync (SingleGridAnswer singleGridAnswer);
        Task UpdateAsync (SingleGridAnswer singleGridAnswer);
        Task DeleteAsync (SingleGridAnswer singleGridAnswer);
    }
}