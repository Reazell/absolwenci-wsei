using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IStudentRepository {
        Task AddAsync (Student student);
        Task<Student> GetByIdAsync (int id, bool isTracking = true);
        Task<Student> GetByIndexNumberAsync (string indexNumber, bool isTracking = true);
        Task<Student> GetByEmailAsync (string email, bool isTracking = true);
    }
}