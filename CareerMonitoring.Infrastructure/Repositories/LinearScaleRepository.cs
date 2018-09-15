// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using CareerMonitoring.Core.Domains.Surveys;
// using CareerMonitoring.Infrastructure.Data;
// using CareerMonitoring.Infrastructure.Repositories.Interfaces;
// using Microsoft.EntityFrameworkCore;

// namespace CareerMonitoring.Infrastructure.Repositories
// {
//     public class LinearScaleRepository : ILinearScaleRepository
//     {
//         private readonly CareerMonitoringContext _context;

//         public LinearScaleRepository (CareerMonitoringContext context) {
//             _context = context;
//         }

//         public async Task AddAsync(LinearScale linearScale)
//         {
//             await _context.LinearScales.AddAsync (linearScale);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task DeleteAsync(LinearScale linearScale)
//         {
//             _context.LinearScales.Remove (linearScale);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task<LinearScale> GetByIdAsync(int id, bool isTracking = true)
//         {
//             if(isTracking)
//                 return await _context.LinearScales.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
//             return await _context.LinearScales.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
//         }

//         public async Task<IEnumerable<LinearScale>> GetBySurveyIdAsync(int surveyId, bool isTracking = true)
//         {
//             if(isTracking)
//                 return await Task.FromResult (_context.LinearScales.AsTracking ().Where (x => x.SurveyId == surveyId));
//             return await Task.FromResult (_context.LinearScales.AsNoTracking ().Where (x => x.SurveyId == surveyId));
//         }

//         public async Task UpdateAsync(LinearScale linearScale)
//         {
//             _context.LinearScales.Update (linearScale);
//             await _context.SaveChangesAsync ();
//         }
//     }
// }