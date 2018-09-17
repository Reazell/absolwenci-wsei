using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class FieldDataAnswerRepository : IFieldDataAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public FieldDataAnswerRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FieldDataAnswer fieldDataAnswer)
        {
            await _context.FieldDataAnswers.AddAsync (fieldDataAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<FieldDataAnswer> GetByIdAsync (int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.FieldDataAnswers.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.FieldDataAnswers.AsNoTracking().SingleOrDefaultAsync (x => x.Id == id);
        }
        public async Task<FieldDataAnswer> GetByQuestionIdAsync(int questionAnswerId, bool isTracking = true)
        {
            if(isTracking)
                return await _context.FieldDataAnswers.AsTracking().SingleOrDefaultAsync (x => x.QuestionAnswerId == questionAnswerId);
            return await _context.FieldDataAnswers.AsNoTracking().SingleOrDefaultAsync (x => x.QuestionAnswerId == questionAnswerId);
        }

        public async Task UpdateAsync(FieldDataAnswer fieldDataAnswer)
        {
            _context.FieldDataAnswers.Update (fieldDataAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(FieldDataAnswer fieldDataAnswer)
        {
            _context.FieldDataAnswers.Remove (fieldDataAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}