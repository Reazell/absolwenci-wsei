using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Extensions.ExceptionHandling;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using NLog;

namespace CareerMonitoring.Infrastructure.Services {
    public class AuthService : IAuthService {
        private readonly IAccountRepository _accountRepository;
        private readonly ICareerOfficeRepository _careerOfficeRepository;
        private readonly ICareerOfficeService _careerOfficeService;
        private readonly IMasterRepository _masterRepository;
        private readonly IMasterService _masterService;
        private readonly IAccountEmailFactory _accountEmailFactory;

        public AuthService (IAccountRepository accountRepository,
            ICareerOfficeRepository careerOfficeRepository,
            ICareerOfficeService careerOfficeService,
            IMasterRepository masterRepository,
            IMasterService masterService,
            IAccountEmailFactory accountEmailFactory) {
            _accountRepository = accountRepository;
            _careerOfficeRepository = careerOfficeRepository;
            _careerOfficeService = careerOfficeService;
            _masterRepository = masterRepository;
            _masterService = masterService;
            _accountEmailFactory = accountEmailFactory;
        }

        public async Task RegisterMasterAsync(string name, string surname, string email, string phoneNumber, string password)
        {
            if (await _masterService.ExistByEmailAsync (email.ToLowerInvariant ()))
                throw new ObjectAlreadyExistException ($"User of given email: {email} already exist.");
            var master = new Master (name, surname, email, phoneNumber, password);
            var activationKey = Guid.NewGuid ();
            master.AddAccountActivation (new AccountActivation (activationKey));
            await _masterRepository.AddAsync (master);
            await _accountEmailFactory.SendActivationEmailAsync (master, activationKey);
        }

        public async Task<Account> LoginAsync (string email, string password) {
            var account = await _accountRepository.GetByEmailAsync (email, false);
            if (account == null || !account.Activated || account.Deleted) {
                return null;
            }
            if (!VerifyPasswordHash (password, account.PasswordHash, account.PasswordSalt))
                return null;
            
            return account;
        }

        
        public async Task RegisterCareerOfficeAsync (string name, string surname, string email, string phoneNumber,
            string password) {
            if (await _careerOfficeService.ExistByEmailAsync (email.ToLowerInvariant ()))
                throw new ObjectAlreadyExistException ($"User of given email: {email} already exist.");
            var careerOffice = new CareerOffice (name, surname, email, phoneNumber, password);
            var activationKey = Guid.NewGuid ();
            careerOffice.AddAccountActivation (new AccountActivation (activationKey));
            await _careerOfficeRepository.AddAsync (careerOffice);
            await _accountEmailFactory.SendActivationEmailAsync (careerOffice, activationKey);
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