using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class RowTemplateRepository : IRowTemplateRepository
    {
        private readonly CareerMonitoringContext _context;
        public RowTemplateRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RowTemplate rowTemplate)
        {
            await _context.RowTemplates.AddAsync (rowTemplate);
            await _context.SaveChangesAsync ();
        }
    }
}