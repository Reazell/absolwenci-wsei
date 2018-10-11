using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Extensions.ExceptionHandling;
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
            if (await ExistByEmailAsync (email))
                throw new ObjectAlreadyExistException ($"User of given email: {email} already exist.");
                 DateTime dateTimeOfCompletion = DateTime.ParseExact(dateOfCompletion, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            if(dateTimeOfCompletion > DateTime.UtcNow){
                throw new Exception("Date of completion cannot be greater than current date.");
            }
            await _unregisteredUserRepository.AddAsync (new UnregisteredUser (name, surname, course, dateOfCompletion, typeOfStudy, email));
        }

        public async Task<IEnumerable<UnregisteredUser>> GetAllAsync () {
            return await _unregisteredUserRepository.GetAllAsync ();
        }

        public async Task UpdateAsync (int id, string name, string surname, string course,
            string dateOfCompletion, string typeOfStudy, string email) {
            var unregisteredUser = await _unregisteredUserRepository.GetByIdAsync (id);
            DateTime dateTimeOfCompletion = DateTime.ParseExact(dateOfCompletion, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            if(dateTimeOfCompletion > DateTime.UtcNow){
                throw new Exception("Date of completion cannot be greater than current date.");
            }
            unregisteredUser.Update (name, surname, course, dateTimeOfCompletion, typeOfStudy, email);
            await _unregisteredUserRepository.UpdateAsync (unregisteredUser);
        }

        public async Task DeleteAsync (int id) {
            var unregisteredUser = await _unregisteredUserRepository.GetByIdAsync (id);
            await _unregisteredUserRepository.DeleteAsync (unregisteredUser);
        }

    }
}