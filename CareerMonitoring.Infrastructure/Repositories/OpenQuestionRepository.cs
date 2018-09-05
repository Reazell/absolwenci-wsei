using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class OpenQuestionRepository : IOpenQuestionRepository
    {
        private readonly CareerMonitoringContext _context;

        public OpenQuestionRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync(OpenQuestion openQuestion)
        {
            await _context.OpenQuestions.AddAsync (openQuestion);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(OpenQuestion openQuestion)
        {
            _context.OpenQuestions.Remove (openQuestion);
            await _context.SaveChangesAsync ();
        }

        public async Task<OpenQuestion> GetByIdAsync(int id, bool isTracking = true)
        {
            if(isTracking)
                return await _context.OpenQuestions.AsTracking().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.OpenQuestions.AsNoTracking().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<IEnumerable<OpenQuestion>> GetBySurveyIdAsync(int surveyId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult (_context.OpenQuestions.AsTracking ().Where (x => x.SurveyId == surveyId));
            return await Task.FromResult (_context.OpenQuestions.AsNoTracking ().Where (x => x.SurveyId == surveyId));
        }

        public async Task UpdateAsync(OpenQuestion openQuestion)
        {
            _context.OpenQuestions.Update (openQuestion);
            await _context.SaveChangesAsync ();
        }
    }
}