using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class UnregisteredUserService : IUnregisteredUserService {
        private readonly IUnregisteredUserRepository _unregisteredUserRepository;

        public UnregisteredUserService (IUnregisteredUserRepository unregisteredUserRepository) {
            _unregisteredUserRepository = unregisteredUserRepository;
        }

        public async Task<bool> ExistByEmailAsync (string email) =>
            await _unregisteredUserRepository.GetByEmailAsync (email, false) != null;

        public async Task CreateAsync (string name, string surname, string email) {
            if (await ExistByEmailAsync (email))
                throw new Exception ("User of given email already exist in database.");
            await _unregisteredUserRepository.AddAsync (new UnregisteredUser (name, surname, email));
        }

        // public async Task UpdateAsync (int id, string name, string surname, string email) {
        //     var unregisteredUser = _unregisteredUserRepository.GetByIdAsync (id);
        //     unregisteredUser.Update (name, surname, email);
        //     await _unregisteredUserRepository.UpdateAsync (unregisteredUser);
        // }

        // public Task DeleteAsync (int id) {
        //     throw new System.NotImplementedException ();
        // }

    }
}