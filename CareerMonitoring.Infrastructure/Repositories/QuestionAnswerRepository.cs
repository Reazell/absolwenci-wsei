using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class QuestionAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public QuestionAnswerRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(QuestionAnswer questionAnswer)
        {
            await _context.QuestionsAnswers.AddAsync(questionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<QuestionAnswer>> GetAllBySurveyIdInOrderAsync(int surveyAnswerId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.QuestionsAnswers.AsTracking ().Where(x => x.SurveyAnswerId == surveyAnswerId).OrderBy(q => q.QuestionPosition));
            return await Task.FromResult(_context.QuestionsAnswers.AsNoTracking ().Where(x => x.SurveyAnswerId == surveyAnswerId).OrderBy(q => q.QuestionPosition));
        }

        public async Task<QuestionAnswer> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.QuestionsAnswers.AsTracking ().SingleOrDefaultAsync(x => x.Id == id);
            return await _context.QuestionsAnswers.AsNoTracking ().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(QuestionAnswer questionAnswer)
        {
            _context.QuestionsAnswers.Update (questionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(QuestionAnswer questionAnswer)
        {
            _context.QuestionsAnswers.Remove (questionAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}