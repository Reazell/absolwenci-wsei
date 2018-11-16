using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IFieldDataAnswerRepository
    {
        Task AddAsync (FieldDataAnswer fieldDataAnswer);
        Task<FieldDataAnswer> GetByIdAsync (int id, bool isTracking = true);
    }
}