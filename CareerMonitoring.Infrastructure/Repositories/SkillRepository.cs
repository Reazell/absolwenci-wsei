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

        public async Task AddAsync (Skill skill) {
            await _context.Skills.AddAsync (skill);
            await _context.SaveChangesAsync ();
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

        public async Task<Skill> GetByNameAsync (string name, bool isTracking = true) {
            if (isTracking){
                return await _context.Skills
                    .AsTracking()
                    .SingleOrDefaultAsync(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());
            }
            return await _context.Skills
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());
        }

        public async Task<IEnumerable<Skill>> GetAllAsync (bool isTracking = true) {
            if (isTracking){
                return await Task.FromResult (_context.Skills
                    .AsTracking ()
                    .AsEnumerable ());
            }
            return await Task.FromResult (_context.Skills
                .AsNoTracking ()
                .AsEnumerable ());
        }

        public async Task UpdateAsync (Skill skill) {
            _context.Skills.Update (skill);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (Skill skill) {
            _context.Skills.Remove (skill);
            await _context.SaveChangesAsync ();
        }
    }
}