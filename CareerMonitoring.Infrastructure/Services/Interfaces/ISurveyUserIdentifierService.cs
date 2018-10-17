using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface ISurveyUserIdentifierService
    {
        Task CreateAsync(string userEmail, int surveyId, int userId);
        Task<string> VerifySurveyUser(string userEmail, int surveyId, int userId);
        Task MarkAnswered(string userEmail, int surveyId, int userId);
    }
}
