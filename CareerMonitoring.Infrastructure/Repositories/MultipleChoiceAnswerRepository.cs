// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using CareerMonitoring.Core.Domains.Surveys.Answers;
// using CareerMonitoring.Infrastructure.Data;
// using CareerMonitoring.Infrastructure.Repositories.Interfaces;
// using Microsoft.EntityFrameworkCore;

// namespace CareerMonitoring.Infrastructure.Repositories
// {
//     public class MultipleChoiceAnswerRepository : IMultipleChoiceAnswerRepository
//     {
//         private readonly CareerMonitoringContext _context;
//         public MultipleChoiceAnswerRepository(CareerMonitoringContext context)
//         {
//             _context = context;
//         }

//         public async Task AddAsync(MultipleChoiceAnswer multipleChoiceAnswer)
//         {
//             await _context.MultipleChoicesAnswers.AddAsync (multipleChoiceAnswer);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task DeleteAsync(MultipleChoiceAnswer multipleChoiceAnswer)
//         {
//             _context.MultipleChoicesAnswers.Remove (multipleChoiceAnswer);
//             await _context.SaveChangesAsync ();
//         }

//         public async Task<MultipleChoiceAnswer> GetByIdAsync(int id, bool isTracking = true)
//         {
//             if(isTracking)
//                 return await _context.MultipleChoicesAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
//             return await _context.MultipleChoicesAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
//         }

//         public async Task<IEnumerable<MultipleChoiceAnswer>> GetAllByQuestionIdAsync(int questionId, bool isTracking = true)
//         {
//             if(isTracking)
//                 return await Task.FromResult (_context.MultipleChoicesAnswers.AsTracking ().Where (x => x.QuestionId == questionId));
//             return await Task.FromResult (_context.MultipleChoicesAnswers.AsNoTracking ().Where (x => x.QuestionId == questionId));
//         }

//         public async Task UpdateAsync(MultipleChoiceAnswer multipleChoiceAnswer)
//         {
//             _context.MultipleChoicesAnswers.Update (multipleChoiceAnswer);
//             await _context.SaveChangesAsync ();
//         }
//     }
// }