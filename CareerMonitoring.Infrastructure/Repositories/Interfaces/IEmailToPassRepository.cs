using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IEmailToPassRepository
    {
        Task AddAsync(EmailToPass emailToPass);
        Task<EmailToPass> GetBySurveyIdAsync(int surveyId);
        Task DeleteAsync(EmailToPass emailToPass);
    }
}