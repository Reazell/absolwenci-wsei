using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class GraduateService : IGraduateService {
        private readonly IGraduateRepository _graduateRepository;

        public GraduateService (IGraduateRepository graduateRepository) {
            _graduateRepository = graduateRepository;
        }

        public async Task<bool> ExistByIdAsync (int id) =>
            await _graduateRepository.GetByIdAsync (id, false) != null;

        public async Task<bool> ExistByEmailAsync (string email) =>
            await _graduateRepository.GetByEmailAsync (email, false) != null;
    }
}