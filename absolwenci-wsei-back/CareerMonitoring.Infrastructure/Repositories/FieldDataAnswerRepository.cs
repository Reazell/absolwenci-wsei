using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class FieldDataAnswerRepository : IFieldDataAnswerRepository {
        private readonly CareerMonitoringContext _context;
        public FieldDataAnswerRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (FieldDataAnswer fieldDataAnswer) {
            await _context.FieldDataAnswers.AddAsync (fieldDataAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<FieldDataAnswer> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.FieldDataAnswers
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.FieldDataAnswers
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }
    }
}