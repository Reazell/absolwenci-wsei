using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class ChoiceOptionAnswerRepository : IChoiceOptionAnswerRepository {
        private readonly CareerMonitoringContext _context;

        public ChoiceOptionAnswerRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (ChoiceOptionAnswer choiceOptionAnswer) {
            await _context.ChoiceOptionsAnswers.AddAsync (choiceOptionAnswer);
            await _context.SaveChangesAsync ();
        }

    }
}