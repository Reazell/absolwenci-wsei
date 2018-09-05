using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ILinearScaleRepository
    {
        Task<LinearScale> GetByIdAsync (int id, bool isTracking = true);
        Task<IEnumerable<LinearScale>> GetBySurveyIdAsync (int surveyId, bool isTracking = true);
        Task AddAsync (LinearScale linearScale);
        Task UpdateAsync (LinearScale linearScale);
        Task DeleteAsync (LinearScale linearScale);
    }
}