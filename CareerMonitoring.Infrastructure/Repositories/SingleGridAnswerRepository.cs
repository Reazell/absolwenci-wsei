// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using CareerMonitoring.Core.Domains.Surveys.Answers;
// using CareerMonitoring.Infrastructure.Data;
// using CareerMonitoring.Infrastructure.Repositories.Interfaces;
// using Microsoft.EntityFrameworkCore;

// namespace CareerMonitoring.Infrastructure.Repositories
// {
//     public class SingleGridAnswerRepository : ISingleGridAnswerRepository
//     {
//         private readonly CareerMonitoringContext _context;
//         public SingleGridAnswerRepository(CareerMonitoringContext context)
//         {
//             _context = context;
//         }

//         public async Task AddAsync(SingleGridAnswer singleGridAnswer)
//         {
//             await _context.SingleGridsAnswers.AddAsync (singleGridAnswer);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task DeleteAsync(SingleGridAnswer singleGridAnswer)
//         {
//             _context.SingleGridsAnswers.Remove (singleGridAnswer);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task<SingleGridAnswer> GetByIdAsync(int id, bool isTracking = true)
//         {
//             if(isTracking)
//                 return await _context.SingleGridsAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
//             return await _context.SingleGridsAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
//         }

//         public async Task<IEnumerable<SingleGridAnswer>> GetAllByQuestionIdAsync(int questionId, bool isTracking = true)
//         {
//             if(isTracking)
//                 return await Task.FromResult (_context.SingleGridsAnswers.AsTracking ().Where (x => x.QuestionId == questionId));
//             return await Task.FromResult (_context.SingleGridsAnswers.AsNoTracking ().Where (x => x.QuestionId == questionId));
//         }

//         public async Task UpdateAsync(SingleGridAnswer singleGridAnswer)
//         {
//             _context.SingleGridsAnswers.Update (singleGridAnswer);
//             await _context.SaveChangesAsync ();
//         }
//     }
// }