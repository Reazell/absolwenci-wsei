using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class RowChoiceOptionAnswerRepository : IRowChoiceOptionAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public RowChoiceOptionAnswerRepository (CareerMonitoringContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RowChoiceOptionAnswer rowChoiceOptionAnswer)
        {
            await _context.RowChoiceOptionsAnswers.AddAsync (rowChoiceOptionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<RowChoiceOptionAnswer>> GetAllByFieldDataIdInOrderAsync(int rowAnswerId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.RowChoiceOptionsAnswers.AsTracking ().Where(x => x.RowAnswerId == rowAnswerId).OrderBy(q => q.OptionPosition));
            return await Task.FromResult(_context.RowChoiceOptionsAnswers.AsNoTracking ().Where(x => x.RowAnswerId == rowAnswerId).OrderBy(q => q.OptionPosition));
        }

        public async Task UpdateAsync(RowChoiceOptionAnswer rowChoiceOptionAnswer)
        {
            _context.RowChoiceOptionsAnswers.Update (rowChoiceOptionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(RowChoiceOptionAnswer rowChoiceOptionAnswer)
        {
            _context.RowChoiceOptionsAnswers.Update (rowChoiceOptionAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}