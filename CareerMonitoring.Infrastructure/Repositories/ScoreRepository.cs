using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Score;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class ScoreRepository : IScoreRepository {
        private readonly CareerMonitoringContext _context;

        public ScoreRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (SurveyScore surveyScore) {
            await _context.SurveyScores.AddAsync (surveyScore);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<QuestionScore>> GetAllBySurveyScoreIdInOrderAsync (int surveyId, bool isTracking = true) {
            if (isTracking)
                return await Task.FromResult (_context.QuestionScores.AsTracking ().Where (x => x.SurveyId == surveyId).OrderBy (q => q.QuestionPosition));
            return await Task.FromResult (_context.QuestionScores.AsNoTracking ().Where (x => x.SurveyId == surveyId).OrderBy (q => q.QuestionPosition));
        }

        public async Task<SurveyScore> GetByIdAsync (int id, bool isTracking = true) {
            throw new System.NotImplementedException ();
        }

        public async Task UpdateAsync (SurveyScore surveyScore) {
            _context.SurveyScores.Update (surveyScore);
            await _context.SaveChangesAsync ();
        }
    }
}