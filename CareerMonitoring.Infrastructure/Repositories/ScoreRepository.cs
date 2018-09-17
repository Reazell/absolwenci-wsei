using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyScore;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class ScoreRepository : ISurveyScoreRepository {
        private readonly CareerMonitoringContext _context;

        public ScoreRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (SurveyScore surveyScore) {
            await _context.SurveyScores.AddAsync (surveyScore);
            await _context.SaveChangesAsync ();
        }

        public async Task<SurveyScore> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking)
                return await _context.SurveyScores.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.SurveyScores.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task UpdateAsync (SurveyScore surveyScore) {
            _context.SurveyScores.Update (surveyScore);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (SurveyScore surveyScore) {
            _context.SurveyScores.Remove (surveyScore);
            await _context.SaveChangesAsync ();
        }
    }
}