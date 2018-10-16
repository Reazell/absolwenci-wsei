using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class EmailToPassRepository : IEmailToPassRepository
    {
        private readonly CareerMonitoringContext _context;


        public EmailToPassRepository(CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EmailToPass emailToPass)
        {
            await _context.AddAsync(emailToPass);
            await _context.SaveChangesAsync();
        }

        public async Task<EmailToPass> GetBySurveyIdAsync(int surveyId)
        {
            return await _context.EmailsToPass.SingleOrDefaultAsync(x => x.SurveyId == surveyId);
        }

        public async Task DeleteAsync(EmailToPass emailToPass)
        {
            _context.Remove(emailToPass);
            await _context.SaveChangesAsync();
        }
    }
}