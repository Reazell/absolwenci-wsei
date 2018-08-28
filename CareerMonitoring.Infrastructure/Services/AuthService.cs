using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class AuthService : IAuthService {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentService _studentService;
        private readonly IAccountEmailFactory _accountEmailFactory;

        public AuthService (IStudentRepository studentRepository,
            IStudentService studentService,
            IAccountEmailFactory accountEmailFactory) {
            _studentRepository = studentRepository;
            _studentService = studentService;
            _accountEmailFactory = accountEmailFactory;
        }

        public async Task<Account> LoginAsync (string email, string password) {
            var student = await _studentRepository.GetByEmailAsync (email, false);
            if (student == null || !student.Activated || student.Deleted)
                throw new Exception ("User of given email and password does not exist!");
            if (!VerifyPasswordHash (password, student.PasswordHash, student.PasswordSalt))
                throw new Exception ("Given email or password are incorrect!");
            return student;
        }

        public async Task RegisterStudentAsync (string name, string surname, string email, int indexNumber, string password) {
            if (await _studentService.ExistByEmailAsync (email.ToLowerInvariant ()))
                throw new Exception ("User of given email already exist.");
            // if (!await _studentService.UserExistByIndexNumberAsync (indexNumber))
            //     throw new Exception ("Given index number does not exist.");
            var student = new Student (name, surname, email, indexNumber, password);
            var activationKey = Guid.NewGuid ();
            student.AddAccountActivation (new AccountActivation (activationKey));
            await _studentRepository.AddAsync (student);
            await _accountEmailFactory.SendActivationEmailAsync (student, activationKey);
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