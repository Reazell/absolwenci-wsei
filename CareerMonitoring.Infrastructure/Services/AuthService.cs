using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class AuthService : IAuthService {
        private readonly IUserRepository _userRepository;

        public AuthService (IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public async Task<User> LoginAsync (string email, string password) {
            throw new System.NotImplementedException ();
        }

        public async Task RegisterAsync (string name, string surname, string email, int indexNumber, string password) {
            var user = new User (name, surname, email, indexNumber, password);
            await _userRepository.AddAsync (user);
        }
    }
}