using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class OpenQuestionAnswerRepository : IOpenQuestionAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public OpenQuestionAnswerRepository(CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OpenQuestionAnswer openQuestionAnswer)
        {
            await _context.OpenQuestionsAnswers.AddAsync (openQuestionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(OpenQuestionAnswer openQuestionAnswer)
        {
            _context.OpenQuestionsAnswers.Remove (openQuestionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<OpenQuestionAnswer> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.OpenQuestionsAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.OpenQuestionsAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<OpenQuestionAnswer>> GetAllByQuestionIdAsync(int questionId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult (_context.OpenQuestionsAnswers.AsTracking ().Where (x => x.QuestionId == questionId));
            return await Task.FromResult (_context.OpenQuestionsAnswers.AsNoTracking ().Where (x => x.QuestionId == questionId));
        }

        public async Task UpdateAsync(OpenQuestionAnswer openQuestionAnswer)
        {
            _context.OpenQuestionsAnswers.Update (openQuestionAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}