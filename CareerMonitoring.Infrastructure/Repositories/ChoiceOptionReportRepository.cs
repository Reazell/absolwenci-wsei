using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class ChoiceOptionReportRepository : IChoiceOptionReportRepository
    {
        private readonly CareerMonitoringContext _context;

        public ChoiceOptionReportRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ChoiceOptionReport choiceOptionReport)
        {
            await _context.ChoiceOptionReports.AddAsync (choiceOptionReport);
            await _context.SaveChangesAsync ();
        }
        public async Task<IEnumerable<ChoiceOptionReport>> GetByQuestionReportAsync(int questionReportId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.ChoiceOptionReports.AsTracking().Where(x => x.QuestionReportId == questionReportId));
            return await Task.FromResult(_context.ChoiceOptionReports.AsNoTracking().Where(x => x.QuestionReportId == questionReportId));
        }

        public async Task UpdateAsync(ChoiceOptionReport choiceOptionReport)
        {
            _context.ChoiceOptionReports.Update (choiceOptionReport);
            await _context.SaveChangesAsync ();
        }
        public async Task DeleteAsync(ChoiceOptionReport choiceOptionReport)
        {
            _context.ChoiceOptionReports.Remove (choiceOptionReport);
            await _context.SaveChangesAsync ();
        }
    }
}