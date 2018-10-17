using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class ChoiceOptionTemplateRepository : IChoiceOptionTemplateRepository
    {
        private readonly CareerMonitoringContext _context;

        public ChoiceOptionTemplateRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ChoiceOptionTemplate choiceOptionTemplate)
        {
            await _context.ChoiceOptionTemplates.AddAsync (choiceOptionTemplate);
            await _context.SaveChangesAsync ();
        }

        public async Task<ChoiceOptionTemplate> GetByIdAsync (int id)
        {
            return await _context.ChoiceOptionTemplates.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ChoiceOptionTemplate>> GetAllByFieldDataIdInOrderAsync(int fieldDataTemplateId,
            bool isTracking = true)
        {
            if(isTracking){
                return await Task.FromResult(_context.ChoiceOptionTemplates
                    .AsTracking()
                    .Where(x => x.FieldDataTemplateId == fieldDataTemplateId)
                    .OrderBy(q => q.OptionPosition));
            }
            return await Task.FromResult(_context.ChoiceOptionTemplates
                .AsNoTracking()
                .Where(x => x.FieldDataTemplateId == fieldDataTemplateId)
                .OrderBy(q => q.OptionPosition));
        }

        public async Task<ChoiceOptionTemplate> GetByFieldDataIdAsync(int fieldDataTemplateId, int optionPosition, bool isTracking=true)
        {
            if(isTracking){
                return await _context.ChoiceOptionTemplates
                    .AsTracking()
                    .Where(x => x.FieldDataTemplateId == fieldDataTemplateId && x.OptionPosition == optionPosition)
                    .SingleOrDefaultAsync();
            }
            return await _context.ChoiceOptionTemplates
                .AsNoTracking()
                .Where(x => x.FieldDataTemplateId == fieldDataTemplateId && x.OptionPosition == optionPosition)
                .SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(ChoiceOptionTemplate choiceOptionTemplate)
        {
            _context.ChoiceOptionTemplates.Update (choiceOptionTemplate);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(ChoiceOptionTemplate choiceOptionTemplate)
        {
            _context.ChoiceOptionTemplates.Update (choiceOptionTemplate);
            await _context.SaveChangesAsync ();
        }
    }
}