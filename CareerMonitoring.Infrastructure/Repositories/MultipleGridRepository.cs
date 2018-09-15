// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using CareerMonitoring.Core.Domains.Surveys;
// using CareerMonitoring.Infrastructure.Data;
// using CareerMonitoring.Infrastructure.Repositories.Interfaces;
// using Microsoft.EntityFrameworkCore;

// namespace CareerMonitoring.Infrastructure.Repositories {
//     public class MultipleGridRepository : IMultipleGridRepository {
//         private readonly CareerMonitoringContext _context;

//         public MultipleGridRepository (CareerMonitoringContext context) {
//             _context = context;
//         }
//         public async Task AddAsync (MultipleGrid multipleGrid) {
//             await _context.MultipleGrids.AddAsync (multipleGrid);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task<MultipleGrid> GetByIdAsync (int id, bool isTracking = true) {
//             if (isTracking)
//                 return await _context.MultipleGrids.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
//             return await _context.MultipleGrids.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);

//         }

//         public async Task<IEnumerable<MultipleGrid>> GetBySurveyIdAsync (int surveyId, bool isTracking = true) {
//             if (isTracking)
//                 return await Task.FromResult (_context.MultipleGrids.AsTracking ().Where (x => x.SurveyId == surveyId));
//             return await Task.FromResult (_context.MultipleGrids.AsNoTracking ().Where (x => x.SurveyId == surveyId));
//         }

//         public async Task UpdateAsync (MultipleGrid multipleGrid) {
//             _context.MultipleGrids.Update (multipleGrid);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task DeleteAsync (MultipleGrid multipleGrid) {
//             _context.MultipleGrids.Remove (multipleGrid);
//             await _context.SaveChangesAsync ();
//         }
//     }
// }