using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.SurveyAnswer;
using CareerMonitoring.Infrastructure.Extensions.Encryptors.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    [Authorize]
    public class SurveyAnswerController : ApiUserController {
        private readonly ISurveyAnswerService _surveyAnswerService;
        private readonly ISurveyUserIdentifierService _surveyUserIdentifierService;
        private readonly IEncryptorFactory _encryptorFactory;

        public SurveyAnswerController (ISurveyAnswerService surveyAnswerService,
            ISurveyUserIdentifierService surveyUserIdentifierService,
            IEncryptorFactory encryptorFactory) {
            _surveyAnswerService = surveyAnswerService;
            _surveyUserIdentifierService = surveyUserIdentifierService;
            _encryptorFactory = encryptorFactory;
        }

        [HttpPost ("{email}/{userId}")]
        public async Task<IActionResult> CreateSurveyAnswer (string email, int userId, [FromBody] SurveyAnswerToAdd command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                var decryptedEmail = _encryptorFactory.DecryptStringValue(email);
                if (await _surveyUserIdentifierService.VerifySurveyUser (decryptedEmail, command.SurveyId, userId) == "answered")
                    return BadRequest ("you already answered to that survey");
                else if (await _surveyUserIdentifierService.VerifySurveyUser (decryptedEmail, command.SurveyId, userId) == "unauthorized")
                    return Unauthorized ();
                await _surveyAnswerService.CreateSurveyAnswerAsync(command);
                await _surveyUserIdentifierService.MarkAnswered(email, command.SurveyId, userId);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
    }
}