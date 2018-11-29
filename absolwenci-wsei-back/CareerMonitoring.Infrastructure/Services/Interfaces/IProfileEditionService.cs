using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IProfileEditionService {
        Task AddCertificateAsync (int accountId, string title, DateTime dateOfReceived);
        Task<IEnumerable<Certificate>> GetCertificatesAsync (int accountId);
        Task DeleteCertificateAsync (int accountId, int certificateId);
        Task AddCourseAsync (int accountId, string name);
        Task<IEnumerable<Course>> GetCoursesAsync (int accountId);
        Task DeleteCourseAsync (int accountId, int courseId);
        Task AddEducationAsync (int accountId, string course, int year, string specialization,
            string nameOfUniveristy, bool graduated);
        Task<IEnumerable<Education>> GetEducationsAsync (int accountId);
        Task DeleteEducationAsync (int accountId, int educationId);
        Task AddExperienceAsync (int accountId, string position, string companyName, string location,
            DateTime from, DateTime to, bool isCurrentJob);
        Task<IEnumerable<Experience>> GetExperiencesAsync (int accountId);
        Task DeleteExperienceAsync (int accountId, int experienceId);
        Task AddLanguageAsync (int accountId, string name, string proficiency);
        Task<IEnumerable<Language>> GetLanguagesAsync (int accountId);
        Task DeleteLanguageAsync (int accountId, int languageId);
        Task AddProfileLinkAsync (int accountId, string content);
        Task<IEnumerable<ProfileLink>> GetProfileLinksAsync (int accountId);
        Task DeleteProfileLinkAsync (int accountId);
        Task AddSkillAsync (int accountId, int skillId);
        Task<IEnumerable<Skill>> GetSkillsAsync (int accountId);
        Task DeleteSkillAsync (int accountId, int skillId);
    }
}