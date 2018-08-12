using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class AuthService : IAuthService {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public AuthService (IUserRepository userRepository, UserService userService) {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<User> LoginAsync (string email, string password) {
            throw new System.NotImplementedException ();
        }

        public async Task RegisterAsync (string name, string surname, string email, int indexNumber, string password) {
            if (await _userService.UserExistByEmailAsync (email.ToLowerInvariant()))
                throw new Exception ("User of given email already exist.");
            if (!await _userService.UserExistByIndexNumberAsync (indexNumber))
                throw new Exception ("Given index number does not exist.");

            var user = new User (name, surname, email, indexNumber, password);
            await _userRepository.AddAsync (user);
        }
    }
}