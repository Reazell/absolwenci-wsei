using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class SurveyAnswerRepository
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
            if (isTracking)
            {
                return await _context.SurveyAnswers.AsTracking ().Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.ChoiceOptionAnswers).Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.RowsAnswers).ThenInclude(x => x.ChoiceOptionAnswers).SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.SurveyAnswers.AsNoTracking ().Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.ChoiceOptionAnswers).Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.RowsAnswers).ThenInclude(x => x.ChoiceOptionAnswers).SingleOrDefaultAsync (x => x.Id == id);
        }
        public async Task<SurveyAnswer> GetByIdAsync(int id, bool isTracking = true)
        {
            if (isTracking)
            {
                return await _context.SurveyAnswers.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.SurveyAnswers.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);
        }
        public async Task<SurveyAnswer> GetByTitleWithQuestionsAsync(string surveyTitle, bool isTracking = true)
        {
            if(isTracking)
            {
                return await _context.SurveyAnswers.AsTracking ().Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.ChoiceOptionAnswers).Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.RowsAnswers).ThenInclude(x => x.ChoiceOptionAnswers).SingleOrDefaultAsync (x => x.SurveyTitle == surveyTitle);
            }
            return await _context.SurveyAnswers.AsNoTracking ().Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.ChoiceOptionAnswers).Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.RowsAnswers).ThenInclude(x => x.ChoiceOptionAnswers).SingleOrDefaultAsync (x => x.SurveyTitle == surveyTitle);
        }

        public async Task<IEnumerable<SurveyAnswer>> GetAllWithQuestionsAsync(bool isTracking = true)
        {
            if (isTracking)
            {
                return await Task.FromResult (_context.SurveyAnswers.AsTracking ().Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.ChoiceOptionAnswers).Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.RowsAnswers).ThenInclude(x => x.ChoiceOptionAnswers).AsEnumerable ());
            }
            return await Task.FromResult (_context.SurveyAnswers.AsNoTracking ().Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.ChoiceOptionAnswers).Include(x => x.QuestionsAnswers).ThenInclude(x => x.FieldDataAnswers).ThenInclude(x => x.RowsAnswers).ThenInclude(x => x.ChoiceOptionAnswers).AsEnumerable ());
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