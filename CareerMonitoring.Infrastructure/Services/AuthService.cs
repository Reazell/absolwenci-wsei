using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Email.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class AuthService : IAuthService {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IUserEmailSender _activationEmailSender;

        public AuthService (IUserRepository userRepository, IUserService userService, IUserEmailSender activationEmailSender) {
            _userRepository = userRepository;
            _userService = userService;
            _activationEmailSender = activationEmailSender;
        }

        public async Task<User> LoginAsync (string email, string password) {
            var user = await _userRepository.GetByEmailAsync (email, false);
            if (user == null || !user.Activated || user.Deleted)
                throw new Exception ("User of given email and password does not exist!");
            if (!VerifyPasswordHash (password, user.PasswordHash, user.PasswordSalt))
                throw new Exception ("Given email or password are incorrect!");
            return user;
        }

        public async Task RegisterAsync (string name, string surname, string email, int indexNumber, string password) {
            if (await _userService.UserExistByEmailAsync (email.ToLowerInvariant ()))
                throw new Exception ("User of given email already exist.");
            // if (!await _userService.UserExistByIndexNumberAsync (indexNumber))
            //     throw new Exception ("Given index number does not exist.");

            var user = new User (name, surname, email, indexNumber, password);
            await _activationEmailSender.SendActivationEmailAsync(user, user.ActivationKey);
            await _userRepository.AddAsync (user);
        }

        private bool VerifyPasswordHash (string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 (passwordSalt)) {
                var computedHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
                for (int i = 0; i < computedHash.Length; i++) {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }
    }
}