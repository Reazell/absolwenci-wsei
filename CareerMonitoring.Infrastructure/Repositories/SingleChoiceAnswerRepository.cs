// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using CareerMonitoring.Core.Domains.Surveys.Answers;
// using CareerMonitoring.Infrastructure.Data;
// using CareerMonitoring.Infrastructure.Repositories.Interfaces;
// using Microsoft.EntityFrameworkCore;

// namespace CareerMonitoring.Infrastructure.Repositories
// {
//     public class SingleChoiceAnswerRepository : ISingleChoiceAnswerRepository
//     {
//         private readonly CareerMonitoringContext _context;
//         public SingleChoiceAnswerRepository(CareerMonitoringContext context)
//         {
//             _context = context;
//         }

//         public async Task AddAsync(SingleChoiceAnswer singleChoiceAnswer)
//         {
//             await _context.SingleChoicesAnswers.AddAsync (singleChoiceAnswer);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task DeleteAsync(SingleChoiceAnswer singleChoiceAnswer)
//         {
//             _context.SingleChoicesAnswers.Remove (singleChoiceAnswer);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task<SingleChoiceAnswer> GetByIdAsync(int id, bool isTracking = true)
//         {
//             if(isTracking)
//                 return await _context.SingleChoicesAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
//             return await _context.SingleChoicesAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
//         }

//         public async Task<IEnumerable<SingleChoiceAnswer>> GetAllByQuestionIdAsync(int questionId, bool isTracking = true)
//         {
//             if(isTracking)
//                 return await Task.FromResult (_context.SingleChoicesAnswers.AsTracking ().Where (x => x.QuestionId == questionId));
//             return await Task.FromResult (_context.SingleChoicesAnswers.AsNoTracking ().Where (x => x.QuestionId == questionId));
//         }

//         public async Task UpdateAsync(SingleChoiceAnswer singleChoiceAnswer)
//         {
//             _context.SingleChoicesAnswers.Update (singleChoiceAnswer);
//             await _context.SaveChangesAsync ();
//         }
//     }
// }