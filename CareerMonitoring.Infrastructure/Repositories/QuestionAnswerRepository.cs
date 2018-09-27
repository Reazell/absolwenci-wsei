using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class QuestionAnswerRepository : IQuestionAnswerRepository {
        private readonly CareerMonitoringContext _context;
        public QuestionAnswerRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (QuestionAnswer questionAnswer) {
            await _context.QuestionsAnswers.AddAsync (questionAnswer);
            await _context.SaveChangesAsync ();
        }

        public int CountAllQuestionAnswersByQuestionId(int surveyAnswerId, int id)
        {
            return _context.QuestionsAnswers.Where(x => x.SurveyAnswerId == surveyAnswerId).Count(x => x.Id == id);
        }

        public async Task<ICollection<QuestionAnswer>> GetAllOpenQuestionAnswersBySurveyAnswerId (int surveyAnswerId)
        {
            return await Task.FromResult(_context.QuestionsAnswers.Where(x => x.SurveyAnswerId == surveyAnswerId && x.Select == "short-answer" || x.Select == "long-answer").ToList());
        }

        public async Task<IEnumerable<QuestionAnswer>> GetAllBySurveyAnswerIdInOrderAsync (int surveyAnswerId, bool isTracking = true) {
            if (isTracking)
                return await Task.FromResult (_context.QuestionsAnswers.AsTracking ().Where (x => x.SurveyAnswerId == surveyAnswerId).OrderBy (q => q.QuestionPosition));
            return await Task.FromResult (_context.QuestionsAnswers.AsNoTracking ().Where (x => x.SurveyAnswerId == surveyAnswerId).OrderBy (q => q.QuestionPosition));
        }

        public async Task<IEnumerable<QuestionAnswer>> GetAllBySurveyIdInOrderAsync(int surveyId,
            bool isTracking = true)
        {
            if (isTracking)
                return await Task.FromResult (_context.QuestionsAnswers.AsTracking ()
                    .Include (x => x.SurveyAnswer)
                    .Include (x => x.FieldDataAnswers)
                    .ThenInclude (x => x.ChoiceOptionAnswers)
                    .Include (x => x.FieldDataAnswers)
                    .ThenInclude (x => x.RowsAnswers)
                    .ThenInclude (x => x.RowChoiceOptionAnswers)
                    .Where (x => x.SurveyAnswer.SurveyId == surveyId)
                    .OrderBy (q => q.QuestionPosition));
            return await Task.FromResult (_context.QuestionsAnswers.AsNoTracking ()
                .Include (x => x.SurveyAnswer)
                .Include (x => x.FieldDataAnswers)
                .ThenInclude (x => x.ChoiceOptionAnswers)
                .Include (x => x.FieldDataAnswers)
                .ThenInclude (x => x.RowsAnswers)
                .ThenInclude (x => x.RowChoiceOptionAnswers)
                .Where (x => x.SurveyAnswer.SurveyId == surveyId)
                .OrderBy (q => q.QuestionPosition));
        }

        public async Task<QuestionAnswer> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking)
                return await _context.QuestionsAnswers.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.QuestionsAnswers.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task UpdateAsync (QuestionAnswer questionAnswer) {
            _context.QuestionsAnswers.Update (questionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (QuestionAnswer questionAnswer) {
            _context.QuestionsAnswers.Remove (questionAnswer);
            await _context.SaveChangesAsync ();
        }

    }
}