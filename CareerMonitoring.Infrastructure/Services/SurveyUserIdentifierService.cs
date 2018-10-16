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

        public async Task CreateAsync(string userEmail, int surveyId)
        {
            var identifier = new SurveyUserIdentifier(userEmail, surveyId);
            await _surveyUserIdentifierRepository.AddAsync(identifier);
        }

        public Task<string> VerifySurveyUser(string userEmail, int surveyId)
        {
            var identifier = _surveyUserIdentifierRepository.GetBySurveyIdAndUserEmailAsync(surveyId, userEmail);
            if(identifier != null && identifier.Answered){
                return Task.FromResult("answered");
            }
            if (identifier != null && !identifier.Answered)
            {
                return Task.FromResult("authorized");
            }
            return Task.FromResult("unauthorized");
        }

        public Task MarkAnswered(string userEmail, int surveyId)
        {
            var identifier = _surveyUserIdentifierRepository.GetBySurveyIdAndUserEmailAsync(surveyId, userEmail);
            identifier.MarkAsAnswered();
            return Task.CompletedTask;
        }
    }
}
