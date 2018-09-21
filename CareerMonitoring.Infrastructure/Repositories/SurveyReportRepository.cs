using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class SurveyReportRepository : ISurveyReportRepository
    {
        private readonly CareerMonitoringContext _context;

        public SurveyReportRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SurveyReport surveyReport)
        {
            await _context.AddAsync (surveyReport);
            await _context.SaveChangesAsync ();
        }

        public async Task<SurveyReport> GetBySurveyIdAsync(int surveyId, bool isTracking = true)
        {
            if(isTracking)
                return await _context.SurveyReports.AsTracking().Where(x => x.SurveyId == surveyId).SingleOrDefaultAsync();
            return await _context.SurveyReports.AsNoTracking().Where(x => x.SurveyId == surveyId).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(SurveyReport surveyReport)
        {
            _context.SurveyReports.Update (surveyReport);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(SurveyReport surveyReport)
        {
            _context.Remove (surveyReport);
            await _context.SaveChangesAsync ();
        }
    }
}