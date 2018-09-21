using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CareerMonitoringContext _context;
        public QuestionRepository(CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<Question>> GetAllBySurveyIdInOrderAsync(int surveyId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.Questions.AsTracking ().Where(x => x.SurveyId == surveyId).OrderBy(q => q.QuestionPosition));
            return await Task.FromResult(_context.Questions.AsNoTracking ().Where(x => x.SurveyId == surveyId).OrderBy(q => q.QuestionPosition));
        }

        public async Task<Question> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.Questions.AsTracking ().SingleOrDefaultAsync(x => x.Id == id);
            return await _context.Questions.AsNoTracking ().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Question> GetByContentAsync (int surveyId, string content, bool isTracking = true)
        {
            if(isTracking)
                return await _context.Questions.AsTracking ().Where (x => x.SurveyId == surveyId).Where(x => x.Content == content).SingleOrDefaultAsync();
            return await _context.Questions.AsNoTracking ().Where (x => x.SurveyId == surveyId).Where(x => x.Content == content).SingleOrDefaultAsync();
        }

        public async Task<Question> GetBySurveyIdAsync (int surveyId, int questionPosition, bool isTracking = true)
        {
            if(isTracking)
                return await _context.Questions.AsTracking ().Where (x => x.SurveyId == surveyId).Where(x => x.QuestionPosition == questionPosition).SingleOrDefaultAsync();
            return await _context.Questions.AsNoTracking ().Where (x => x.SurveyId == surveyId).Where(x => x.QuestionPosition == questionPosition).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Questions.Update (question);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(Question question)
        {
            _context.Questions.Remove (question);
            await _context.SaveChangesAsync ();
        }
    }
}