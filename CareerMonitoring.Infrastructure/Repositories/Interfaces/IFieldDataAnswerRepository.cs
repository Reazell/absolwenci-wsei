using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IFieldDataAnswerRepository
    {
        Task AddAsync (FieldDataAnswer fieldDataAnswer);
        Task<FieldDataAnswer> GetByQuestionIdAsync (int questionAnswerId, bool isTracking = true);
        Task<FieldDataAnswer> GetByIdAsync (int id, bool isTracking = true);
        Task UpdateAsync (FieldDataAnswer fieldDataAnswer);
        Task DeleteAsync (FieldDataAnswer fieldDataAnswer);
    }
}