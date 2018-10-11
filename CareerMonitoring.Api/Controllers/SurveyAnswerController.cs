using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.SurveyAnswer;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    [Authorize]
    public class SurveyAnswerController : ApiUserController {
        private readonly ISurveyAnswerService _surveyAnswerService;
        private readonly ISurveyUserIdentifierService _surveyUserIdentifierService;

        public SurveyAnswerController (ISurveyAnswerService surveyAnswerService,
            ISurveyUserIdentifierService surveyUserIdentifierService) {
            _surveyAnswerService = surveyAnswerService;
            _surveyUserIdentifierService = surveyUserIdentifierService;
        }

        [HttpPost ("{email}")]
        public async Task<IActionResult> CreateSurveyAnswer (string email, [FromBody] SurveyAnswerToAdd command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                if (await _surveyUserIdentifierService.VerifySurveyUser (email, command.SurveyId) == "unauthorized")
                    return Unauthorized ();
                else if (await _surveyUserIdentifierService.VerifySurveyUser (email, command.SurveyId) == "answered")
                    return BadRequest ("you already answered to that survey");
                await _surveyAnswerService.CreateSurveyAnswerAsync(command);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
    }
}