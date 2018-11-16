using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class RowChoiceOptionAnswerRepository : IRowChoiceOptionAnswerRepository {
        private readonly CareerMonitoringContext _context;

        public RowChoiceOptionAnswerRepository (CareerMonitoringContext context) {
            _context = context;
        }
        public async Task AddAsync (RowChoiceOptionAnswer rowChoiceOptionAnswer) {
            await _context.RowChoiceOptionsAnswers.AddAsync (rowChoiceOptionAnswer);
            await _context.SaveChangesAsync ();
        }
    }
}