using System;
using System.Collections;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Extensions.ExceptionHandling;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.Services {
    public class ProfileEditionService : IProfileEditionService {
        private readonly IAccountRepository _accountRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICertificateRepository _certificateRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IExperienceRepository _experienceRepository;
        private readonly IProfileLinkRepository _profileLinkRepository;

        public ProfileEditionService (
            IAccountRepository accountRepository,
            ISkillRepository skillRepository,
            ILanguageRepository languageRepository,
            ICertificateRepository certificateRepository,
            ICourseRepository courseRepository,
            IEducationRepository educationRepository,
            IExperienceRepository experienceRepository,
            IProfileLinkRepository profileLinkRepository) {
            _accountRepository = accountRepository;
            _skillRepository = skillRepository;
            _languageRepository = languageRepository;
            _certificateRepository = certificateRepository;
            _courseRepository = courseRepository;
            _educationRepository = educationRepository;
            _experienceRepository = experienceRepository;
            _profileLinkRepository = profileLinkRepository;
        }

        public async Task AddCertificateAsync (int accountId, string title, DateTime dateOfReceived) {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            try {
                account.AddCertificate (new Certificate (accountId, title, dateOfReceived));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
        }

        public async Task<IEnumerable<Certificate>> GetCertificates(int accountId)
        {
            return await _certificateRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task AddCourseAsync (int accountId, string name) {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            try {
                account.AddCourse (new Course (name));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
        }

        public async Task<IEnumerable<Course>> GetCourses(int accountId)
        {
            return await _courseRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task AddEducationAsync (int accountId, string course, int year, string specialization,
            string nameOfUniveristy, bool graduated) {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            try {
                account.AddEducation (new Education (course, year, specialization, nameOfUniveristy, graduated));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
        }

        public async Task<IEnumerable<Education>> GetEducations(int accountId)
        {
            return await _educationRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task AddExperienceAsync (int accountId, string position, string companyName, string location,
            DateTime from, DateTime to, bool isCurrentJob) {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            try {
                account.AddExperience (new Experience (position, companyName, location, from, to, isCurrentJob));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
        }

        public async Task<IEnumerable<Experience>> GetExperiences(int accountId)
        {
            return await _experienceRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task AddLanguageAsync (int accountId, string name, string proficiency) {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            try {
                account.AddLanguage (new Language (name, proficiency));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
        }

        public async Task<IEnumerable<Language>> GetLanguages(int accountId)
        {
            return await _languageRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task AddProfileLinkAsync (int accountId, string content) {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            try {
                account.AddProfileLink (new ProfileLink (content));
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
        }

        public async Task<IEnumerable<ProfileLink>> GetProfileLinks(int accountId)
        {
            return await _profileLinkRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task AddSkillAsync (int accountId, int skillId) {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            var skill = await _skillRepository.GetByIdAsync (skillId);
            try {
                account.AddSkill (skill);
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
        }

        public async Task<IEnumerable<Skill>> GetSkills(int accountId)
        {
            return await _skillRepository.GetAllByUserIdAsync(accountId);
        }
    }
}