using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IRowAnswerRepository {
        Task AddAsync (RowAnswer rowAnswer);
        Task<RowAnswer> GetByIdAsync (int id, bool isTracking = true);
    }
}