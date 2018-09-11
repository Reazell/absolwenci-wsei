using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public AnswerRepository(CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Answer answer)
        {
            await _context.Answers.AddAsync (answer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(Answer answer)
        {
            _context.Answers.Remove (answer);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<Answer>> GetAllAsync (bool isTracking = true) {
            if (isTracking)
                return await Task.FromResult (_context.Answers.AsTracking ().AsEnumerable ());
            return await Task.FromResult (_context.Answers.AsNoTracking ().AsEnumerable ());
        }

        public async Task<Answer> GetByIdAsync(int id, bool isTracking = true)
        {
            if (isTracking)
                return await _context.Answers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.Answers.AsNoTracking().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task UpdateAsync(Answer answer)
        {
            _context.Answers.Update (answer);
            await _context.SaveChangesAsync ();
        }
    }
}