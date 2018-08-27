using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class StudentService : IStudentService {
        private readonly IStudentRepository _studentRepository;

        public StudentService (IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task<bool> UserExistByIdAsync (int id) =>
            await _studentRepository.GetByIdAsync (id, false) != null;

        public async Task<bool> UserExistByIndexNumberAsync (int indexNumber) =>
            await _studentRepository.GetByIndexNumberAsync (indexNumber, false) != null;

        public async Task<bool> UserExistByEmailAsync (string email) =>
            await _studentRepository.GetByEmailAsync (email, false) != null;
    }
}