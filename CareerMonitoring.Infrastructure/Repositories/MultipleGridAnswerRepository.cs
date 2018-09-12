using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class MultipleGridAnswerRepository : IMultipleGridAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public MultipleGridAnswerRepository(CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MultipleGridAnswer multipleGridAnswer)
        {
            await _context.MultipleGridsAnswers.AddAsync (multipleGridAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(MultipleGridAnswer multipleGridAnswer)
        {
            _context.MultipleGridsAnswers.Remove (multipleGridAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<MultipleGridAnswer> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.MultipleGridsAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.MultipleGridsAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<MultipleGridAnswer>> GetAllByQuestionIdAsync(int questionId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult (_context.MultipleGridsAnswers.AsTracking ().Where (x => x.QuestionId == questionId));
            return await Task.FromResult (_context.MultipleGridsAnswers.AsNoTracking ().Where (x => x.QuestionId == questionId));
        }

        public async Task UpdateAsync(MultipleGridAnswer multipleGridAnswer)
        {
            _context.MultipleGridsAnswers.Update (multipleGridAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}