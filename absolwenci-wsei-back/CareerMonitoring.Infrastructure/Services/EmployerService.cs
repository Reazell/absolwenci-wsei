using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class EmployerService : IEmployerService {
        private readonly IEmployerRepository _employerRepository;

        public EmployerService (IEmployerRepository employerRepository) {
            _employerRepository = employerRepository;
        }

        public async Task<bool> ExistByEmailAsync (string email) =>
            await _employerRepository.GetByEmailAsync (email, false) != null;
    }
}