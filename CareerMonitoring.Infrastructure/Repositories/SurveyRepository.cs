using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class SurveyRepository : ISurveyRepository {
        private readonly CareerMonitoringContext _context;

        public SurveyRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (Survey survey) {
            await _context.Surveys.AddAsync (survey);
            await _context.SaveChangesAsync ();
        }

        public async Task<Survey> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking)
                return await _context.Surveys.AsTracking ().SingleOrDefaultAsync (x => x.Id == id);
            return await _context.Surveys.AsNoTracking ().SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Survey> GetByIdWithQuestionsAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.Surveys.AsTracking ()
                    .Include (x => x.LinearScales)
                    .Include (x => x.MultipleChoices)
                    .Include (x => x.SingleChoices)
                    .Include (x => x.OpenQuestions)
                    .Include (x => x.SingleGrids)
                    .Include (x => x.MultipleGrids).SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Surveys.AsNoTracking ()
                .Include (x => x.LinearScales)
                .Include (x => x.MultipleChoices)
                .Include (x => x.SingleChoices)
                .Include (x => x.OpenQuestions)
                .Include (x => x.SingleGrids)
                .Include (x => x.MultipleGrids).SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Survey> GetByIdWithQuestionsAndAnswersAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.Surveys.AsTracking ()
                    .Include (x => x.LinearScales)
                    .ThenInclude (c => c.LinearScaleAnswers)
                    .Include (x => x.MultipleChoices)
                    .ThenInclude (c => c.MultipleChoiceAnswers)
                    .Include (x => x.SingleChoices)
                    .ThenInclude (c => c.SingleChoiceAnswers)
                    .Include (x => x.OpenQuestions)
                    .Include (x => x.SingleGrids)
                    .ThenInclude (c => c.SingleGridAnswers)
                    .Include (x => x.MultipleGrids)
                    .ThenInclude (c => c.MultipleGridAnswers).SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Surveys.AsNoTracking ()
                .Include (x => x.LinearScales)
                .Include (x => x.MultipleChoices)
                .Include (x => x.SingleChoices)
                .Include (x => x.OpenQuestions)
                .Include (x => x.SingleGrids)
                .Include (x => x.MultipleGrids).SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Survey> GetByTitleWithQuestionsAsync (string title, bool isTracking = true) {
            if (isTracking) {
                return await _context.Surveys.AsTracking ()
                    .Include (x => x.LinearScales)
                    .Include (x => x.MultipleChoices)
                    .Include (x => x.SingleChoices)
                    .Include (x => x.OpenQuestions)
                    .Include (x => x.SingleGrids)
                    .Include (x => x.MultipleGrids).SingleOrDefaultAsync (x => x.Title == title);
            }
            return await _context.Surveys.AsNoTracking ()
                .Include (x => x.LinearScales)
                .Include (x => x.MultipleChoices)
                .Include (x => x.SingleChoices)
                .Include (x => x.OpenQuestions)
                .Include (x => x.SingleGrids)
                .Include (x => x.MultipleGrids).SingleOrDefaultAsync (x => x.Title == title);
        }

        public async Task<IEnumerable<Survey>> GetAllWithQuestionsAsync (bool isTracking = true) {
            if (isTracking) {
                return await Task.FromResult (_context.Surveys.AsTracking ()
                    .Include (x => x.LinearScales)
                    .Include (x => x.MultipleChoices)
                    .Include (x => x.SingleChoices)
                    .Include (x => x.SingleGrids)
                    .Include (x => x.MultipleGrids)
                    .Include (x => x.OpenQuestions).AsEnumerable ());
            }
            return await Task.FromResult (_context.Surveys.AsNoTracking ()
                .Include (x => x.LinearScales)
                .Include (x => x.MultipleChoices)
                .Include (x => x.SingleChoices)
                .Include (x => x.SingleGrids)
                .Include (x => x.MultipleGrids)
                .Include (x => x.OpenQuestions).AsEnumerable ());
        }

        public async Task UpdateAsync (Survey survey) {
            _context.Surveys.Update (survey);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (Survey survey) {
            _context.Surveys.Remove (survey);
            await _context.SaveChangesAsync ();
        }
    }
}