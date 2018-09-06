using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IMultipleGridRepository {

        Task AddAsync (MultipleGrid multipleGrid);
        Task<MultipleGrid> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<MultipleGrid>> GetBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task UpdateAsync (MultipleGrid multipleGrid);
        Task DeleteAsync (MultipleGrid multipleGrid);
    }
}