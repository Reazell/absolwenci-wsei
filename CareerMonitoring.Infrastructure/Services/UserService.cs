using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;

        public UserService (IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task ActivateAsync (Guid activationKey) {
            var user = await _userRepository.GetByActivationKeyAsync (activationKey);
            if (user == null) {
                throw new Exception ("Your activation key is incorrect");
            }
            user.Activate (activationKey);
            await _userRepository.UpdateAsync (user);
        }

        public async Task<bool> UserExistByIdAsync (int id) =>
            await _userRepository.GetByIdAsync (id, false) != null;

        public async Task<bool> UserExistByIndexNumberAsync (int indexNumber) =>
            await _userRepository.GetByIndexNumberAsync (indexNumber, false) != null;

        public async Task<bool> UserExistByEmailAsync (string email) =>
            await _userRepository.GetByEmailAsync (email, false) != null;
    }
}