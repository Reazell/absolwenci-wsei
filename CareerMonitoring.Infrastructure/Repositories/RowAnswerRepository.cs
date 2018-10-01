using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class RowAnswerRepository : IRowAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public RowAnswerRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RowAnswer rowAnswer)
        {
            await _context.RowAnswers.AddAsync (rowAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<RowAnswer>> GetAllByFieldDataIdInOrderAsync(int fieldDataAnswerId,
            bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.RowAnswers.AsTracking()
                    .Where(x => x.FieldDataAnswerId == fieldDataAnswerId).OrderBy(q => q.RowPosition));
            return await Task.FromResult(_context.RowAnswers.AsNoTracking()
                .Where(x => x.FieldDataAnswerId == fieldDataAnswerId).OrderBy(q => q.RowPosition));
        }

        public async Task<RowAnswer> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.RowAnswers.AsTracking ().SingleOrDefaultAsync(x => x.Id == id);
            return await _context.RowAnswers.AsNoTracking ().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(RowAnswer rowAnswer)
        {
            _context.RowAnswers.Update (rowAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(RowAnswer rowAnswer)
        {
            _context.RowAnswers.Update (rowAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}