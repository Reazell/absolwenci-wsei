using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class SurveyUserIdentifierService : ISurveyUserIdentifierService {
        private readonly ISurveyUserIdentifierRepository _surveyUserIdentifierRepository;

        public SurveyUserIdentifierService (ISurveyUserIdentifierRepository surveyUserIdentifierRepository) {
            _surveyUserIdentifierRepository = surveyUserIdentifierRepository;
        }

        public async Task CreateAsync (string userEmail, int surveyId) {
            var identifier = new SurveyUserIdentifier (userEmail, surveyId);
            await _surveyUserIdentifierRepository.AddAsync (identifier);
        }

        public async Task<string> VerifySurveyUser (string userEmail, int surveyId) {
            var counter = 0;
            var identifiers = await _surveyUserIdentifierRepository.GetAllBySurveyIdAsync (surveyId);
            foreach (var identifier in identifiers) {
                if (VerifyEmailHash (userEmail, identifier.UserEmailHash)) {
                    counter++;
                }
                if (identifier != null && identifier.Answered) {
                    return await Task.FromResult ("answered");
                }
                if (identifier != null && !identifier.Answered) {
                    identifier.MarkAsAnswered ();
                    await _surveyUserIdentifierRepository.UpdateAsync (identifier);
                    return await Task.FromResult ("authorized");
                }
                if(counter == 0){
                    return await Task.FromResult ("unauthorized");
                }
            }
            return "";
        }

        private bool VerifyEmailHash (string input, string hash) {
            if (input == null || hash == null) {
                return false;
            }
            return input.Equals (hash);
        }
    }
}