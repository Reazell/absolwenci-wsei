using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Profile;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class ProfileEditionInterface : IProfileEditionInterface {
        private readonly IAccountRepository _accountRepository;

        public ProfileEditionInterface (IAccountRepository accountRepository) {
            _accountRepository = accountRepository;
        }

        public async Task AddCertificateAsync (int accountId, string title, DateTime dateOfReceived) {
            var account = await _accountRepository.GetByIdAsync (accountId);
            try {
                account.AddCertificate (new Certificate (title, dateOfReceived));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new Exception (e.Message);
            }
        }

        public async Task AddCourseAsync (int accountId, string name) {
            var account = await _accountRepository.GetByIdAsync (accountId);
            try {
                account.AddCourse (new Course (name));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new Exception (e.Message);
            }
        }

        public async Task AddEducationAsync (int accountId, string course, int year, string specialization, string nameOfUniveristy, bool graduated) {
            var account = await _accountRepository.GetByIdAsync (accountId);
            try {
                account.AddEducation (new Education (course, year, specialization, nameOfUniveristy, graduated));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new Exception (e.Message);
            }
        }

        public async Task AddExperienceAsync (int accountId, string position, string companyName, string location, DateTime from, DateTime to, bool isCurrentJob) {
            var account = await _accountRepository.GetByIdAsync (accountId);
            try {
                account.AddExperience (new Experience (position, companyName, location, from, to, isCurrentJob));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new Exception (e.Message);
            }
        }

        public async Task AddProfileLinkAsync (int accountId, string content) {
            var account = await _accountRepository.GetByIdAsync (accountId);
            try {
                account.AddProfileLink (new ProfileLink (content));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new Exception (e.Message);
            }
        }
    }
}