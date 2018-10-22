using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class QuestionRepository : IQuestionRepository {
        private readonly CareerMonitoringContext _context;

        public QuestionRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (Question question) {
            await _context.Questions.AddAsync (question);
            await _context.SaveChangesAsync ();
        }

        public async Task<Question> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking) {
                return await _context.Questions
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Questions
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }
    }
}