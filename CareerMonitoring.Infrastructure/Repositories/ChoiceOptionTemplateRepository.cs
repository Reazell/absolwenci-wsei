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
    }
}