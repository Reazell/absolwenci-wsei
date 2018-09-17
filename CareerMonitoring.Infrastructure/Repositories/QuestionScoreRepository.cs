using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyScore;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class QuestionScoreRepository : IQuestionScoreRepository {
        private readonly CareerMonitoringContext _context;

        public QuestionScoreRepository (CareerMonitoringContext context) {
            _context = context;
        }
        public async Task<IEnumerable<QuestionScore>> GetAllBySurveyScoreIdInOrderAsync (int surveyId, bool isTracking = true) {
            if (isTracking)
                return await Task.FromResult (_context.QuestionScores.AsTracking ()
                    .Include (x => x.FieldData)
                    .ThenInclude (x => x.ChoiceOptions)
                    .Include (x => x.FieldData)
                    .ThenInclude (x => x.Rows)
                    .Where (x => x.SurveyId == surveyId)
                    .OrderBy (q => q.QuestionPosition));
            return await Task.FromResult (_context.QuestionScores.AsNoTracking ()
                .Include (x => x.FieldData)
                .ThenInclude (x => x.ChoiceOptions)
                .Include (x => x.FieldData)
                .ThenInclude (x => x.Rows)
                .Where (x => x.SurveyId == surveyId)
                .OrderBy (q => q.QuestionPosition));
        }
    }
}