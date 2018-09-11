using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface ISingleGridRepository {

        Task AddAsync (SingleGrid singleGrid);
        Task<SingleGrid> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<SingleGrid>> GetBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task UpdateAsync (SingleGrid singleGrid);
        Task DeleteAsync (SingleGrid singleGrid);
    }
}