using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class StudentRepository : IStudentRepository {
        private readonly CareerMonitoringContext _context;

        public StudentRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAsync (Student student) {
            await _context.Students.AddAsync (student);
            await _context.SaveChangesAsync ();
        }

        public async Task<Student> GetByIdAsync (int id, bool isTracking = true) {
            if (isTracking){
                return await _context.Students
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.Id == id);
            }
            return await _context.Students
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.Id == id);
        }

        public async Task<Student> GetByIndexNumberAsync (string indexNumber, bool isTracking = true) {
            if (isTracking){
                return await _context.Students
                    .AsTracking ()
                    .SingleOrDefaultAsync (x => x.IndexNumber == indexNumber);
            }
            return await _context.Students
                .AsNoTracking ()
                .SingleOrDefaultAsync (x => x.IndexNumber == indexNumber);
        }

        public async Task<Student> GetByEmailAsync (string email, bool isTracking = true) {
            if (isTracking){
                return await _context.Students
                    .AsTracking()
                    .SingleOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
            }
            return await _context.Students
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
        }

        public async Task<IEnumerable<Student>> GetAllAsync (bool isTracking = true) {
            if (isTracking){
                return await Task.FromResult (_context.Students
                    .AsTracking ()
                    .AsEnumerable ());
            }
            return await Task.FromResult (_context.Students
                .AsNoTracking ()
                .AsEnumerable ());
        }

        public async Task UpdateAsync (Student student) {
            _context.Students.Update (student);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (Student student) {
            _context.Students.Remove (student);
            await _context.SaveChangesAsync ();
        }
    }
}