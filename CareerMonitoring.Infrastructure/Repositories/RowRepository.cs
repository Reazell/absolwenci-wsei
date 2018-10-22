using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class RowRepository : IRowRepository {
        private readonly CareerMonitoringContext _context;

        public RowRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (Row row) {
            await _context.Rows.AddAsync (row);
            await _context.SaveChangesAsync ();
        }

    }
}