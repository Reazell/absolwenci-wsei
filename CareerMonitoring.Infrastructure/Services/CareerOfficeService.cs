using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class CareerOfficeService : ICareerOfficeService {
        private readonly ICareerOfficeRepository _careerOfficeRepository;

        public CareerOfficeService (ICareerOfficeRepository careerOfficeRepository) {
            _careerOfficeRepository = careerOfficeRepository;
        }

        public async Task<bool> ExistByIdAsync (int id) =>
            await _careerOfficeRepository.GetByIdAsync (id, false) != null;

        public async Task<bool> ExistByEmailAsync (string email) =>
            await _careerOfficeRepository.GetByEmailAsync (email, false) != null;
    }
}