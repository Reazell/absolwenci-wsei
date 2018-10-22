using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class SurveyUserIdentifierRepository : ISurveyUserIdentifierRepository {
        private readonly CareerMonitoringContext _context;

        public SurveyUserIdentifierRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (SurveyUserIdentifier surveyUserIdentifier) {
            await _context.AddAsync (surveyUserIdentifier);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<SurveyUserIdentifier>> GetAllBySurveyIdAsync (int surveyId) {
            return await Task.FromResult (_context.SurveyUserIdentifiers.Where (x => x.SurveyId == surveyId));
        }

        public async Task UpdateAsync (SurveyUserIdentifier surveyUserIdentifier) {
            _context.Update (surveyUserIdentifier);
            await _context.SaveChangesAsync ();
        }
    }
}