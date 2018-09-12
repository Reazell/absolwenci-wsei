using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ILinearScaleAnswerRepository
    {
        Task<LinearScaleAnswer> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<LinearScaleAnswer>> GetAllByQuestionIdAsync (int questionId, bool isTracking = true);
        Task AddAsync (LinearScaleAnswer linearScaleAnswer);
        Task UpdateAsync (LinearScaleAnswer linearScaleAnswer);
        Task DeleteAsync (LinearScaleAnswer linearScaleAnswer);
    }
}