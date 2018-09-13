using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class LinearScaleAnswerRepository : ILinearScaleAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public LinearScaleAnswerRepository(CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LinearScaleAnswer linearScaleAnswer)
        {
            await _context.LinearScalesAnswers.AddAsync (linearScaleAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(LinearScaleAnswer linearScaleAnswer)
        {
            _context.LinearScalesAnswers.Remove (linearScaleAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<LinearScaleAnswer> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.LinearScalesAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.LinearScalesAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<LinearScaleAnswer>> GetAllByQuestionIdAsync(int questionId, bool isTracking = true)
        {
             if(isTracking)
                return await Task.FromResult (_context.LinearScalesAnswers.AsTracking ().Where (x => x.QuestionId == questionId));
            return await Task.FromResult (_context.LinearScalesAnswers.AsNoTracking ().Where (x => x.QuestionId == questionId));
        }

        public async Task UpdateAsync(LinearScaleAnswer linearScaleAnswer)
        {
            _context.LinearScalesAnswers.Update (linearScaleAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}