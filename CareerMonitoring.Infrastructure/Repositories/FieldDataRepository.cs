using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class FieldDataRepository : IFieldDataRepository
    {
        private readonly CareerMonitoringContext _context;
        public FieldDataRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public Task AddAsync(FieldData fieldData)
        {
            throw new System.NotImplementedException();
        }
        public Task<FieldData> GetByQuestionIdAsync(int questionId, bool isTracking = true)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(FieldData fieldData)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(FieldData fieldData)
        {
            throw new System.NotImplementedException();
        }
    }
}