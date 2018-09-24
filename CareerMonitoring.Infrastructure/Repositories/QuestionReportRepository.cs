using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class QuestionReportRepository : IQuestionReportRepository
    {
        private readonly CareerMonitoringContext _context;

        public QuestionReportRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(QuestionReport questionReport)
        {
            await _context.QuestionReports.AddAsync (questionReport);
            await _context.SaveChangesAsync ();
        }

        public async Task<QuestionReport> GetByIdAsync (int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.QuestionReports.AsTracking().SingleOrDefaultAsync ();
            return await _context.QuestionReports.AsNoTracking().SingleOrDefaultAsync ();
        }

        public async Task<QuestionReport> GetBySurveyReportAsync(int surveyReportId, int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.QuestionReports.AsTracking().Where(x => x.SurveyReportId == surveyReportId).Where(x => x.Id == id).SingleOrDefaultAsync ();
            return await _context.QuestionReports.AsNoTracking().Where(x => x.SurveyReportId == surveyReportId).Where(x => x.Id == id).SingleOrDefaultAsync ();
        }

        public async Task UpdateAsync(QuestionReport questionReport)
        {
            _context.QuestionReports.Update (questionReport);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(QuestionReport questionReport)
        {
            _context.QuestionReports.Remove (questionReport);
            await _context.SaveChangesAsync ();
        }
    }
}