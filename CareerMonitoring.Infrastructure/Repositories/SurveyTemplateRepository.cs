using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class SurveyTemplateRepository : ISurveyTemplateRepository
    {
        private readonly CareerMonitoringContext _context;

        public SurveyTemplateRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (SurveyTemplate surveyTemplate) {
            await  _context.SurveyTemplates.AddAsync (surveyTemplate);
            await _context.SaveChangesAsync ();
        }

        public async Task<SurveyTemplate> GetByIdWithQuestionTemplatesAsync (int id, bool isTracking = true) {
            if (isTracking){
                return await _context.SurveyTemplates
                    .AsTracking ()
                    .Include (x => x.QuestionTemplates)
                    .ThenInclude (x => x.FieldDataTemplates)
                    .ThenInclude (x => x.ChoiceOptionTemplates)
                    .Include (x => x.QuestionTemplates)
                    .ThenInclude (x => x.FieldDataTemplates)
                    .ThenInclude (x => x.RowTemplates)
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.SurveyTemplates
                .AsNoTracking ()
                .Include (x => x.QuestionTemplates)
                .ThenInclude (x => x.FieldDataTemplates)
                .ThenInclude (x => x.ChoiceOptionTemplates)
                .Include (x => x.QuestionTemplates)
                .ThenInclude (x => x.FieldDataTemplates)
                .ThenInclude (x => x.RowTemplates)
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<SurveyTemplate> GetByTitleWithQuestionTemplatesAsync (string title, bool isTracking = true) {
            if (isTracking) {
                return await _context.SurveyTemplates
                    .AsTracking()
                    .Include(x => x.QuestionTemplates)
                    .SingleOrDefaultAsync(x => x.Title == title);
            }
            return await _context.SurveyTemplates
                .AsNoTracking()
                .Include(x => x.QuestionTemplates)
                .SingleOrDefaultAsync(x => x.Title == title);
        }

        public async Task<IEnumerable<SurveyTemplate>> GetAllWithQuestionTemplatesAsync (bool isTracking = true) {
            if (isTracking) {
                return await Task.FromResult(_context.SurveyTemplates
                    .AsTracking()
                    .Include(x => x.QuestionTemplates)
                    .AsEnumerable());
            }
            return await Task.FromResult (_context.SurveyTemplates
                .AsNoTracking ()
                .Include (x => x.QuestionTemplates)
                .AsEnumerable ());
        }

        public async Task<SurveyTemplate> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking){
                return await _context.SurveyTemplates
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.SurveyTemplates
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<SurveyTemplate>> GetAllWithQuestionTemplatesFieldDataTemplatesAndChoiceOptionTemplatesByTitleAsync (string title,
            bool isTracking = true) {
            if (isTracking) {
                return await Task.FromResult (_context.SurveyTemplates
                    .AsTracking ()
                    .Include (x => x.QuestionTemplates)
                    .ThenInclude (x => x.FieldDataTemplates)
                    .ThenInclude (x => x.ChoiceOptionTemplates)
                    .Include (x => x.QuestionTemplates)
                    .ThenInclude (x => x.FieldDataTemplates)
                    .ThenInclude (x => x.RowTemplates)
                    .AsEnumerable ());
            }
            return await Task.FromResult (_context.SurveyTemplates
                .AsNoTracking ()
                .Include (x => x.QuestionTemplates)
                .ThenInclude (x => x.FieldDataTemplates)
                .ThenInclude (x => x.ChoiceOptionTemplates)
                .Include (x => x.QuestionTemplates)
                .ThenInclude (x => x.FieldDataTemplates)
                .ThenInclude (x => x.RowTemplates)
                .AsEnumerable ());
        }

        public async Task UpdateAsync (SurveyTemplate surveyTemplate) {
            _context.SurveyTemplates.Update (surveyTemplate);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (SurveyTemplate surveyTemplate) {
            _context.SurveyTemplates.Remove (surveyTemplate);
            await _context.SaveChangesAsync ();
        }
    }
}