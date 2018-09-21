using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class RowReportRepository : IRowReportRepository
    {
        private readonly CareerMonitoringContext _context;
        public RowReportRepository (CareerMonitoringContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RowReport rowReport)
        {
            await _context.RowReports.AddAsync (rowReport);
            await _context.SaveChangesAsync ();
        }

        public async Task<RowReport> GetByQuestionReportAsync(int questionReportId, bool isTracking = true)
        {
            if(isTracking)
                return await _context.RowReports.AsTracking().Where(x => x.QuestionReportId == questionReportId).SingleOrDefaultAsync ();
            return await _context.RowReports.AsNoTracking().Where(x => x.QuestionReportId == questionReportId).SingleOrDefaultAsync ();
        }

        public async Task UpdateAsync(RowReport rowReport)
        {
            _context.RowReports.Update (rowReport);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(RowReport rowReport)
        {
            _context.RowReports.Remove (rowReport);
            await _context.SaveChangesAsync ();
        }
    }
}