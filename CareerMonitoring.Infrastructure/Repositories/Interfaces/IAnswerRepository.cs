using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<Answer>> GetAllByQuestionIdAsync (int questionId, bool isTracking = true);
        Task AddAsync (Answer answer);
        Task UpdateAsync (Answer answer);
        Task DeleteAsync (Answer answer);
    }
}