using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IMultipleGridAnswerRepository
    {
        Task<MultipleGridAnswer> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<MultipleGridAnswer>> GetAllByQuestionIdAsync (int questionId, bool isTracking = true);
        Task AddAsync (MultipleGridAnswer multipleGridAnswer);
        Task UpdateAsync (MultipleGridAnswer multipleGridAnswer);
        Task DeleteAsync (MultipleGridAnswer multipleGridAnswer);
    }
}