using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class QuestionTemplateRepository : IQuestionTemplateRepository {
        private readonly CareerMonitoringContext _context;

        public QuestionTemplateRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (QuestionTemplate questionTemplate) {
            await _context.QuestionTemplates.AddAsync (questionTemplate);
            await _context.SaveChangesAsync ();
        }

        public async Task<QuestionTemplate> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.QuestionTemplates
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.QuestionTemplates
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task DeleteAsync (QuestionTemplate questionTemplate) {
            _context.QuestionTemplates.Remove (questionTemplate);
            await _context.SaveChangesAsync ();
        }
    }
}