using CareerMonitoring.Core.Domains.Surveys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface ISurveyUserIdentifierRepository
    {
        Task AddAsync(SurveyUserIdentifier surveyUserIdentifier);
        SurveyUserIdentifier GetBySurveyIdAndUserEmailAsync(int surveyId, string userEmail);
        Task DeleteAsync(SurveyUserIdentifier surveyUserIdentifier);
    }
}
