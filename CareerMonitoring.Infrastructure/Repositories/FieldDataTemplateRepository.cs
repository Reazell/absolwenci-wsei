using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class FieldDataTemplateRepository : IFieldDataTemplateRepository {
        private readonly CareerMonitoringContext _context;
        public FieldDataTemplateRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (FieldDataTemplate fieldDataTemplate) {
            await _context.FieldDataTemplates.AddAsync (fieldDataTemplate);
            await _context.SaveChangesAsync ();
        }

        public async Task<FieldDataTemplate> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.FieldDataTemplates
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.FieldDataTemplates
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }
    }
}