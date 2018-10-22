using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class QuestionAnswerRepository : IQuestionAnswerRepository {
        private readonly CareerMonitoringContext _context;

        public QuestionAnswerRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (QuestionAnswer questionAnswer) {
            await _context.QuestionsAnswers.AddAsync (questionAnswer);
            await _context.SaveChangesAsync ();
        }

        public async Task<QuestionAnswer> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.QuestionsAnswers
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.QuestionsAnswers
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }
    }
}