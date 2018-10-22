using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface ISurveyUserIdentifierRepository {
        Task AddAsync (SurveyUserIdentifier surveyUserIdentifier);
        Task<IEnumerable<SurveyUserIdentifier>> GetAllBySurveyIdAsync (int surveyId);
        Task UpdateAsync (SurveyUserIdentifier surveyUserIdentifier);
    }
}