using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class ChoiceOptionRepository : IChoiceOptionRepository
    {
        private readonly CareerMonitoringContext _context;
        public ChoiceOptionRepository (CareerMonitoringContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ChoiceOption choiceOption)
        {
            await _context.ChoiceOptions.AddAsync (choiceOption);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<ChoiceOption>> GetAllByFieldDataIdInOrderAsync(int fieldDataId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.ChoiceOptions.AsTracking ().Where(x => x.FieldDataId == fieldDataId).OrderBy(q => q.OptionPosition));
            return await Task.FromResult(_context.ChoiceOptions.AsNoTracking ().Where(x => x.FieldDataId == fieldDataId).OrderBy(q => q.OptionPosition));
        }

        public async Task<ChoiceOption> GetByFieldDataIdAsync (int fieldDataId, bool isTracking = true)
        {
            if (isTracking)
                return await _context.ChoiceOptions.AsTracking ().SingleOrDefaultAsync (x => x.FieldDataId == fieldDataId);
            return await _context.ChoiceOptions.AsNoTracking ().SingleOrDefaultAsync (x => x.FieldDataId == fieldDataId);
        }

        public async Task UpdateAsync(ChoiceOption choiceOption)
        {
            _context.ChoiceOptions.Update (choiceOption);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(ChoiceOption choiceOption)
        {
            _context.ChoiceOptions.Update (choiceOption);
            await _context.SaveChangesAsync ();
        }
    }
}