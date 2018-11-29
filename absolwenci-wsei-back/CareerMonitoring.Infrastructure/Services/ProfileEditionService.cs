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

        public async Task<IEnumerable<Certificate>> GetCertificatesAsync (int accountId)
        {
            return await _certificateRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task DeleteCertificateAsync(int accountId, int certificateId)
        {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            var certificate = await _certificateRepository.GetByIdAsync(certificateId);
            try {
                account.RemoveCertificate(certificate);
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
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

        public async Task<IEnumerable<Course>> GetCoursesAsync (int accountId)
        {
            return await _courseRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task DeleteCourseAsync(int accountId, int courseId)
        {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            var course = await _courseRepository.GetByIdAsync(courseId);
            try {
                account.RemoveCourse(course);
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
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

        public async Task<IEnumerable<Education>> GetEducationsAsync (int accountId)
        {
            return await _educationRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task DeleteEducationAsync(int accountId, int educationId)
        {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            var education = await _educationRepository.GetByIdAsync(educationId);
            try {
                account.RemoveEducation(education);
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
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

        public async Task<IEnumerable<Experience>> GetExperiencesAsync (int accountId)
        {
            return await _experienceRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task DeleteExperienceAsync(int accountId, int experienceId)
        {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            var experience = await _experienceRepository.GetByIdAsync(experienceId);
            try {
                account.RemoveExperience(experience);
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
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

        public async Task<IEnumerable<Language>> GetLanguagesAsync (int accountId)
        {
            return await _languageRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task DeleteLanguageAsync(int accountId, int languageId)
        {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            var language = await _languageRepository.GetByIdAsync(languageId);
            try {
                account.RemoveLanguage (language);
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
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

        public async Task<IEnumerable<ProfileLink>> GetProfileLinksAsync (int accountId)
        {
            return await _profileLinkRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task DeleteProfileLinkAsync(int accountId)
        {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            try {
                account.RemoveProfileLink();
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
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

        public async Task<IEnumerable<Skill>> GetSkillsAsync (int accountId)
        {
            return await _skillRepository.GetAllByUserIdAsync(accountId);
        }

        public async Task DeleteSkillAsync(int accountId, int skillId)
        {
            var account = await _accountRepository.GetWithProfileEditionByIdAsync (accountId);
            var skill = await _skillRepository.GetByIdAsync(skillId);
            try {
                account.RemoveSkill(skill);
                await _accountRepository.UpdateAsync (account);
            } catch (Exception e) {
                throw new InccorectRoleException (e.Message, e);
            }
        }
    }
}