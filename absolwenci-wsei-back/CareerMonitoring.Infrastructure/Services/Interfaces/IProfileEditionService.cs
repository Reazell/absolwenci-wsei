using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IProfileEditionService {
        Task AddCertificateAsync (int accountId, string title, DateTime dateOfReceived);
        Task<IEnumerable<Certificate>> GetCertificates (int accountId);
        Task AddCourseAsync (int accountId, string name);
        Task<IEnumerable<Course>> GetCourses (int accountId);
        Task AddEducationAsync (int accountId, string course, int year, string specialization,
            string nameOfUniveristy, bool graduated);
        Task<IEnumerable<Education>> GetEducations (int accountId);
        Task AddExperienceAsync (int accountId, string position, string companyName, string location,
            DateTime from, DateTime to, bool isCurrentJob);
        Task<IEnumerable<Experience>> GetExperiences (int accountId);
        Task AddLanguageAsync (int accountId, string name, string proficiency);
        Task<IEnumerable<Language>> GetLanguages (int accountId);
        Task AddProfileLinkAsync (int accountId, string content);
        Task<IEnumerable<ProfileLink>> GetProfileLinks (int accountId);
        Task AddSkillAsync (int accountId, int skillId);
        Task<IEnumerable<Skill>> GetSkills (int accountId);
    }
}