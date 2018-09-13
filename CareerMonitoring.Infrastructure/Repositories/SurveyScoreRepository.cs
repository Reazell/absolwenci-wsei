using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Score;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class SurveyScoreRepository : ISurveyScoreRepository {
        private readonly CareerMonitoringContext _context;

        public SurveyScoreRepository (CareerMonitoringContext context) {
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
        public async Task<SurveyScore> GetBySurveyIdAsync (int surveyId, bool isTracking = true) {
            if (isTracking)
                return await _context.SurveyScores.AsTracking ().SingleOrDefaultAsync (x => x.SurveyId == surveyId);
            return await _context.SurveyScores.AsNoTracking ().SingleOrDefaultAsync (x => x.SurveyId == surveyId);
        }

        public async Task<SurveyScore> GetByTitleAsync (string title, bool isTracking = true) {
            if (isTracking)
                return await _context.SurveyScores.AsTracking ().SingleOrDefaultAsync (x => x.Title == title);
            return await _context.SurveyScores.AsNoTracking ().SingleOrDefaultAsync (x => x.Title == title);
        }

        public async Task<SurveyScore> GetWithAllScoresByIdAsync (int id, bool isTracking = true) {
            if (isTracking)
                return await _context.SurveyScores.AsTracking ()
                    .Include (x => x.LinearScaleScores)
                    .Include (x => x.MultipleChoiceScores)
                    .Include (x => x.MultipleGridScores)
                    .Include (x => x.SingleChoiceScores)
                    .Include (x => x.SingleGridScores)
                    .SingleOrDefaultAsync (x => x.Id == id);

            return await _context.SurveyScores.AsTracking ()
                .Include (x => x.LinearScaleScores)
                .Include (x => x.MultipleChoiceScores)
                .Include (x => x.MultipleGridScores)
                .Include (x => x.SingleChoiceScores)
                .Include (x => x.SingleGridScores)
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<SurveyScore> GetWithAllScoresBySurveyIdAsync (int surveyId, bool isTracking = true) {
            if (isTracking)
                return await _context.SurveyScores.AsTracking ()
                    .Include (x => x.LinearScaleScores)
                    .Include (x => x.MultipleChoiceScores)
                    .Include (x => x.MultipleGridScores)
                    .Include (x => x.SingleChoiceScores)
                    .Include (x => x.SingleGridScores)
                    .SingleOrDefaultAsync (x => x.SurveyId == surveyId);

            return await _context.SurveyScores.AsTracking ()
                .Include (x => x.LinearScaleScores)
                .Include (x => x.MultipleChoiceScores)
                .Include (x => x.MultipleGridScores)
                .Include (x => x.SingleChoiceScores)
                .Include (x => x.SingleGridScores)
                .SingleOrDefaultAsync (x => x.SurveyId == surveyId);
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