using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class SingleGridRepository : ISingleGridRepository {
        private readonly CareerMonitoringContext _context;

        public SingleGridRepository (CareerMonitoringContext context) {
            _context = context;
        }
        public async Task AddAsync (SingleGrid singleGrid) {
            await _context.SingleGrids.AddAsync (singleGrid);
            await _context.SaveChangesAsync ();
        }

        public async Task<SingleGrid> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking)
                return await _context.SingleGrids.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.SingleGrids.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);

        }

        public async Task<IEnumerable<SingleGrid>> GetBySurveyIdAsync (int surveyId, bool isTracking = true) {
            if (isTracking)
                return await Task.FromResult (_context.SingleGrids.AsTracking ().Where (x => x.SurveyId == surveyId));
            return await Task.FromResult (_context.SingleGrids.AsNoTracking ().Where (x => x.SurveyId == surveyId));
        }

        public async Task UpdateAsync (SingleGrid singleGrid) {
            _context.SingleGrids.Update (singleGrid);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (SingleGrid singleGrid) {
            _context.SingleGrids.Remove (singleGrid);
            await _context.SaveChangesAsync ();
        }
    }
}