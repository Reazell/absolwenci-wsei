using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class ChoiceOptionRepository : IChoiceOptionRepository
    {
        private readonly CareerMonitoringContext _context;

        public ChoiceOptionRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ChoiceOption choiceOption)
        {
            await _context.ChoiceOptions.AddAsync (choiceOption);
            await _context.SaveChangesAsync ();
        }

      
    }
}