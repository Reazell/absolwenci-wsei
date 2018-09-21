using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class RowChoiceOptionReportRepository : IRowChoiceOptionReportRepository
    {
        private readonly CareerMonitoringContext _context;

        public RowChoiceOptionReportRepository (CareerMonitoringContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RowChoiceOptionReport rowChoiceOptionReport)
        {
            await _context.RowChoiceOptionReports.AddAsync (rowChoiceOptionReport);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RowChoiceOptionReport>> GetBySurveyReportAsync(int rowReportId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.RowChoiceOptionReports.AsTracking().Where(x => x.RowReportId == rowReportId));
            return await Task.FromResult(_context.RowChoiceOptionReports.AsNoTracking().Where(x => x.RowReportId == rowReportId));
        }

        public async Task UpdateAsync(RowChoiceOptionReport rowChoiceOptionReport)
        {
            _context.RowChoiceOptionReports.Update (rowChoiceOptionReport);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(RowChoiceOptionReport rowChoiceOptionReport)
        {
            _context.RowChoiceOptionReports.Remove (rowChoiceOptionReport);
            await _context.SaveChangesAsync ();
        }
    }
}