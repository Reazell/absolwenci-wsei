using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class SurveyAnswerRepository : ISurveyAnswerRepository
    {
        private readonly CareerMonitoringContext _context;

        public SurveyAnswerRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SurveyAnswer surveyAnswer)
        {
            await _context.SurveyAnswers.AddAsync (surveyAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<SurveyAnswer> GetByIdWithQuestionsAsync(int id, bool isTracking = true)
        {
            if (isTracking){
                return await _context.SurveyAnswers
                    .AsTracking ()
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.ChoiceOptionAnswers)
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.RowsAnswers)
                    .ThenInclude(x => x.RowChoiceOptionAnswers)
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.SurveyAnswers
                .AsNoTracking ()
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.ChoiceOptionAnswers)
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.RowsAnswers)
                .ThenInclude(x => x.RowChoiceOptionAnswers)
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<SurveyAnswer> GetBySurveyIdWithQuestionsAsync(int surveyId, bool isTracking = true)
        {
            if (isTracking){
                return await _context
                    .SurveyAnswers
                    .AsTracking ()
                    .Where(x => x.SurveyId == surveyId)
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.ChoiceOptionAnswers)
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.RowsAnswers)
                    .ThenInclude(x => x.RowChoiceOptionAnswers)
                    .SingleOrDefaultAsync ();
            }
            return await _context.SurveyAnswers
                .AsNoTracking ()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.ChoiceOptionAnswers)
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.RowsAnswers)
                .ThenInclude(x => x.RowChoiceOptionAnswers)
                .SingleOrDefaultAsync ();
        }

        public async Task<SurveyAnswer> GetBySurveyIdAsync (int surveyId, bool isTracking = true)
        {
            if(isTracking){
                return await _context.SurveyAnswers
                    .AsTracking()
                    .SingleOrDefaultAsync(x => x.SurveyId == surveyId);
            }
            return await _context.SurveyAnswers
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.SurveyId == surveyId);
        }

        public async Task<SurveyAnswer> GetByIdAsync(int id, bool isTracking = true)
        {
            if (isTracking){
                return await _context.SurveyAnswers
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.SurveyAnswers
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }
        public async Task<SurveyAnswer> GetByTitleWithQuestionsAsync(string surveyTitle, bool isTracking = true)
        {
            if(isTracking){
                return await _context.SurveyAnswers
                    .AsTracking ()
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.ChoiceOptionAnswers)
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.RowsAnswers)
                    .ThenInclude(x => x.RowChoiceOptionAnswers)
                    .SingleOrDefaultAsync (x => x.SurveyTitle == surveyTitle);
            }
            return await _context.SurveyAnswers
                .AsNoTracking ()
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.ChoiceOptionAnswers)
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.RowsAnswers)
                .ThenInclude(x => x.RowChoiceOptionAnswers)
                .SingleOrDefaultAsync (x => x.SurveyTitle == surveyTitle);
        }

        public async Task<ICollection<SurveyAnswer>> GetAllBySurveyIdWithQuestionsAsync(int surveyId,
            bool isTracking = true)
        {
            if (isTracking){
                return await Task.FromResult (_context.SurveyAnswers
                    .AsTracking ()
                    .Where(x => x.SurveyId == surveyId)
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.ChoiceOptionAnswers)
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.RowsAnswers)
                    .ThenInclude(x => x.RowChoiceOptionAnswers)
                    .ToList ());
            }
            return await Task.FromResult (_context.SurveyAnswers
                .AsNoTracking ()
                .Where(x => x.SurveyId == surveyId)
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.ChoiceOptionAnswers)
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.RowsAnswers)
                .ThenInclude(x => x.RowChoiceOptionAnswers)
                .ToList ());
        }

        public async Task<int> CountAllSurveyAnswersBySurveyIdAsync(int surveyId)
        {
            return await _context.SurveyAnswers
                .CountAsync(x => x.SurveyId == surveyId);
        }

        public async Task<IEnumerable<SurveyAnswer>> GetAllWithQuestionsAsync(bool isTracking = true)
        {
            if (isTracking){
                return await Task.FromResult (_context.SurveyAnswers
                    .AsTracking ()
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.ChoiceOptionAnswers)
                    .Include(x => x.QuestionsAnswers)
                    .ThenInclude(x => x.FieldDataAnswers)
                    .ThenInclude(x => x.RowsAnswers)
                    .ThenInclude(x => x.RowChoiceOptionAnswers)
                    .AsEnumerable ());
            }
            return await Task.FromResult (_context.SurveyAnswers
                .AsNoTracking ()
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.ChoiceOptionAnswers)
                .Include(x => x.QuestionsAnswers)
                .ThenInclude(x => x.FieldDataAnswers)
                .ThenInclude(x => x.RowsAnswers)
                .ThenInclude(x => x.RowChoiceOptionAnswers)
                .AsEnumerable ());
        }

        public async Task UpdateAsync(SurveyAnswer surveyAnswer)
        {
            _context.SurveyAnswers.Update (surveyAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(SurveyAnswer surveyAnswer)
        {
            _context.SurveyAnswers.Remove (surveyAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}