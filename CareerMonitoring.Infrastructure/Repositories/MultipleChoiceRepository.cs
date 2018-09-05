using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class MultipleChoiceRepository : IMultipleChoiceRepository
    {
        private readonly CareerMonitoringContext _context;

        public MultipleChoiceRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync(MultipleChoice multipleChoice)
        {
            await _context.MultipleChoices.AddAsync (multipleChoice);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(MultipleChoice multipleChoice)
        {
            _context.MultipleChoices.Remove (multipleChoice);
            await _context.SaveChangesAsync ();
        }

        public async Task<MultipleChoice> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.MultipleChoices.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.MultipleChoices.AsNoTracking().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<MultipleChoice>> GetBySurveyIdAsync(int surveyId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult (_context.MultipleChoices.AsTracking ().Where (x => x.SurveyId == surveyId));
            return await Task.FromResult (_context.MultipleChoices.AsNoTracking ().Where (x => x.SurveyId == surveyId));
        }

        public async Task UpdateAsync(MultipleChoice multipleChoice)
        {
            _context.Update (multipleChoice);
            await _context.SaveChangesAsync ();
        }
    }
}