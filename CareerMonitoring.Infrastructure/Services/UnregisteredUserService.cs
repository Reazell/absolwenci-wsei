using System;
using System.Collections.Generic;
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

        public async Task CreateAsync (string name, string surname, string course,
            DateTime dateOfCompletion, string typeOfStudy, string email) {
            if (await ExistByEmailAsync (email)){
                throw new Exception ("User of given email already exist in database.");
            }
            await _unregisteredUserRepository.AddAsync (new UnregisteredUser (name, surname, course, dateOfCompletion, typeOfStudy, email));
        }

        public async Task<IEnumerable<UnregisteredUser>> GetAllAsync () {
            return await _unregisteredUserRepository.GetAllAsync ();
        }

        public async Task UpdateAsync (int id, string name, string surname, string course,
            DateTime dateOfCompletion, string typeOfStudy, string email) {
            var unregisteredUser = await _unregisteredUserRepository.GetByIdAsync (id);
            unregisteredUser.Update (name, surname, course, dateOfCompletion, typeOfStudy, email);
            await _unregisteredUserRepository.UpdateAsync (unregisteredUser);
        }

        public async Task DeleteAsync (int id) {
            var unregisteredUser = await _unregisteredUserRepository.GetByIdAsync (id);
            await _unregisteredUserRepository.DeleteAsync (unregisteredUser);
        }

    }
}