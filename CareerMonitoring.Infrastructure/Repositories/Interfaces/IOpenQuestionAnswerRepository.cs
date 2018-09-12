using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IOpenQuestionAnswerRepository
    {
        Task<OpenQuestionAnswer> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<OpenQuestionAnswer>> GetAllByQuestionIdAsync (int questionId, bool isTracking = true);
        Task AddAsync (OpenQuestionAnswer openQuestionAnswer);
        Task UpdateAsync (OpenQuestionAnswer openQuestionAnswer);
        Task DeleteAsync (OpenQuestionAnswer openQuestionAnswer);
    }
}