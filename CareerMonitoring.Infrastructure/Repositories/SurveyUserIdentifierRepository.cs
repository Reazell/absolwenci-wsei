using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class SurveyUserIdentifierRepository : ISurveyUserIdentifierRepository
    {
        private readonly CareerMonitoringContext _context;

        public SurveyUserIdentifierRepository(CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SurveyUserIdentifier surveyUserIdentifier)
        {
            await _context.AddAsync(surveyUserIdentifier);
            await _context.SaveChangesAsync();
        }

        public SurveyUserIdentifier GetBySurveyIdAndUserEmailAsync(int surveyId, string userEmail, int userId)
        {
            return _context.SurveyUserIdentifiers
                .SingleOrDefault(x => x.SurveyId == surveyId && x.UserEmail == userEmail && x.UserId == userId);
        }

        public async Task UpdateAsync(SurveyUserIdentifier surveyUserIdentifier)
        {
            _context.Update(surveyUserIdentifier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SurveyUserIdentifier surveyUserIdentifier)
        {
            _context.Remove(surveyUserIdentifier);
            await _context.SaveChangesAsync();
        }
    }
}
