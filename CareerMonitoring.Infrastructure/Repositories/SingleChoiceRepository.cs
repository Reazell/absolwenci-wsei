using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class SingleChoiceRepository : ISingleChoiceRepository
    {
        private readonly CareerMonitoringContext _context;

        public SingleChoiceRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync(SingleChoice singleChoice)
        {
            await _context.SingleChoices.AddAsync (singleChoice);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(SingleChoice singleChoice)
        {
            _context.SingleChoices.Remove (singleChoice);
            await _context.SaveChangesAsync ();
        }

        public async Task<SingleChoice> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.SingleChoices.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.SingleChoices.AsNoTracking().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<SingleChoice>> GetBySurveyIdAsync(int surveyId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult (_context.SingleChoices.AsTracking ().Where (x => x.SurveyId == surveyId));
            return await Task.FromResult (_context.SingleChoices.AsNoTracking ().Where (x => x.SurveyId == surveyId));
        }

        public async Task UpdateAsync(SingleChoice singleChoice)
        {
            _context.SingleChoices.Update (singleChoice);
            await _context.SaveChangesAsync ();
        }
    }
}