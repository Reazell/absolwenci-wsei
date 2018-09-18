using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    public class SurveyScoreController : ApiUserController {
        private readonly ISurveyScoreService _surveyScoreService;
        private readonly ISurveyService _surveyService;

        public SurveyScoreController (ISurveyScoreService surveyScoreService,
            ISurveyService surveyService) {
            _surveyScoreService = surveyScoreService;
            _surveyService = surveyService;
        }

        [HttpGet ("report/{surveyId}")]
        public async Task<IActionResult> GetReport (int surveyId) {
            var survey = await _surveyService.GetByIdAsync (surveyId);
            var surveyScore = _surveyScoreService.CountScore (survey);
            return Json (surveyScore);
        }
    }
}