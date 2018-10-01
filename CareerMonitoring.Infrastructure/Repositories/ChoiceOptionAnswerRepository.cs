using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class ChoiceOptionAnswerRepository : IChoiceOptionAnswerRepository
    {
        private readonly CareerMonitoringContext _context;
        public ChoiceOptionAnswerRepository (CareerMonitoringContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ChoiceOptionAnswer choiceOptionAnswer)
        {
            await _context.ChoiceOptionsAnswers.AddAsync (choiceOptionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<ChoiceOptionAnswer>> GetAllByFieldDataIdInOrderAsync(int fieldDataAnswerId,
            bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.ChoiceOptionsAnswers.AsTracking()
                    .Where(x => x.FieldDataAnswerId == fieldDataAnswerId).OrderBy(q => q.OptionPosition));
            return await Task.FromResult(_context.ChoiceOptionsAnswers.AsNoTracking()
                .Where(x => x.FieldDataAnswerId == fieldDataAnswerId).OrderBy(q => q.OptionPosition));
        }

        public int CountMarkedByOptionPositionAsync(int fieldDataAnswerId, int optionPosition)
        {
            return _context.ChoiceOptionsAnswers.Where(x => x.Value == true && x.OptionPosition == optionPosition)
                .Count(x => x.FieldDataAnswerId == fieldDataAnswerId);
        }

        public async Task UpdateAsync(ChoiceOptionAnswer choiceOptionAnswer)
        {
            _context.ChoiceOptionsAnswers.Update (choiceOptionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(ChoiceOptionAnswer choiceOptionAnswer)
        {
            _context.ChoiceOptionsAnswers.Update (choiceOptionAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}