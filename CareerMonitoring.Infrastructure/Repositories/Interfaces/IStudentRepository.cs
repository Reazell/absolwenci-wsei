using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IStudentRepository {
        Task AddAsync (Student student);
        Task<Student> GetByIdAsync (int id, bool isTracking = true);
        Task<Student> GetByIndexNumberAsync (int indexNumber, bool isTracking = true);
        Task<Student> GetByEmailAsync (string email, bool isTracking = true);
        Task<IEnumerable<Student>> BrowseAsync ();
        Task UpdateAsync (Student student);
        Task DeleteAsync (Student student);
    }
}