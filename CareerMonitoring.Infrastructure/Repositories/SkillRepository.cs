using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class SkillRepository : ISkillRepository {
        private readonly CareerMonitoringContext _context;

        public SkillRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task<Skill> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking){
                return await _context.Skills
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Skills
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }
    }
}