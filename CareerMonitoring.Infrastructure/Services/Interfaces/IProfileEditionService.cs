using System;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IProfileEditionService {
        Task AddCertificateAsync (int accountId, string title, DateTime dateOfReceived);
        Task AddCourseAsync (int accountId, string name);
        Task AddEducationAsync (int accountId, string course, int year, string specialization,
            string nameOfUniveristy, bool graduated);
        Task AddExperienceAsync (int accountId, string position, string companyName, string location,
            DateTime from, DateTime to, bool isCurrentJob);
        Task AddProfileLinkAsync (int accountId, string content);
    }
}