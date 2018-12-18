using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Extensions.ExceptionHandling;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using NLog;

namespace CareerMonitoring.Infrastructure.Services {
    public class UnregisteredUserService : IUnregisteredUserService {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger ();
        private readonly IUnregisteredUserRepository _unregisteredUserRepository;
        private readonly IAccountService _accountService;

        public UnregisteredUserService (IUnregisteredUserRepository unregisteredUserRepository,
            IAccountService accountService) {
            _unregisteredUserRepository = unregisteredUserRepository;
            _accountService = accountService;
        }

        public async Task<bool> ExistByEmailAsync (string email) =>
            await _unregisteredUserRepository.GetByEmailAsync (email, false) != null;

        public async Task CreateAsync (string name, string surname, string email) {
            if (await ExistByEmailAsync (email) || await _accountService.ExistsByEmailAsync (email))
                throw new ObjectAlreadyExistException ($"User of given email: {email} already exist.");
            await _unregisteredUserRepository.AddAsync (new UnregisteredUser (name, surname, email));
        }

        public async Task<IEnumerable<UnregisteredUser>> GetAllAsync () {
            return await _unregisteredUserRepository.GetAllAsync ();
        }

        public async Task<UnregisteredUser> GetByIdAsync (int id) {
            return await _unregisteredUserRepository.GetByIdAsync (id);
        }

        public async Task UpdateAsync (int id, string name, string surname, string email) {
            var unregisteredUser = await _unregisteredUserRepository.GetByIdAsync (id);
            Logger.Info ($"Updating unregistered user with Id {id}.");
            unregisteredUser.Update (name, surname, email);
            await _unregisteredUserRepository.UpdateAsync (unregisteredUser);
        }

        public async Task DeleteAsync (int id) {
            var unregisteredUser = await _unregisteredUserRepository.GetByIdAsync (id);
            Logger.Info ($"Deleting unregistered user with Id {unregisteredUser.Id}.");
            await _unregisteredUserRepository.DeleteAsync (unregisteredUser);
        }
    }
}