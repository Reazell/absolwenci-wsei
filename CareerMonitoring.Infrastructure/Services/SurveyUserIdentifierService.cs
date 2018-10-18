using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Services
{
    public class SurveyUserIdentifierService : ISurveyUserIdentifierService
    {
        private readonly ISurveyUserIdentifierRepository _surveyUserIdentifierRepository;

        public SurveyUserIdentifierService(ISurveyUserIdentifierRepository surveyUserIdentifierRepository)
        {
            _surveyUserIdentifierRepository = surveyUserIdentifierRepository;
        }

        public async Task CreateAsync(string userEmail, int surveyId, int userId)
        {
            var identifier = new SurveyUserIdentifier(userEmail, surveyId, userId);
            await _surveyUserIdentifierRepository.AddAsync(identifier);
        }

        public Task<string> VerifySurveyUser(string userEmail, int surveyId, int userId)
        {
            var identifier = _surveyUserIdentifierRepository.GetBySurveyIdAndUserEmailAsync(surveyId, userEmail, userId);
            if(identifier != null && identifier.Answered){
                return Task.FromResult("answered");
            }
            if (identifier != null && !identifier.Answered)
            {
                return Task.FromResult("authorized");
            }
            return Task.FromResult("unauthorized");
        }

        public async Task MarkAnswered(string userEmail, int surveyId, int userId)
        {
            var identifier = _surveyUserIdentifierRepository.GetBySurveyIdAndUserEmailAsync(surveyId, userEmail, userId);
            identifier.MarkAsAnswered();
            await _surveyUserIdentifierRepository.UpdateAsync(identifier);
            await Task.CompletedTask;
        }
    }
}
