using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class FieldDataRepository : IFieldDataRepository {
        private readonly CareerMonitoringContext _context;

        public FieldDataRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (FieldData fieldData) {
            await _context.FieldData.AddAsync (fieldData);
            await _context.SaveChangesAsync ();
        }

        public async Task<FieldData> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.FieldData
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.FieldData
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }
    }
}