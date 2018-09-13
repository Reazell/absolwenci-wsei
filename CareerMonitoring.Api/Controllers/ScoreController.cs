using CareerMonitoring.Core.Domains.Surveys.Score;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    public class ScoreController : ApiUserController {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IReportService _reportService;

        public ScoreController (ISurveyRepository surveyRepository,
            IReportService reportService) {
            _surveyRepository = surveyRepository;
            _reportService = reportService;
        }

        [HttpPost ("score")]
        public async Task<IActionResult> GetScore ([FromBody] int surveyId) {
            var survey = _surveyRepository.GetByIdWithQuestionsAndAnswersAsync (surveyId);
            var singleChoiceAnswers = await _reportService.CountSingleChoiceAnswers (survey.SingleChoices);
            var SurveyScore = new SurveyScore (survey);
            return Json (SurveyScore);
        }
    }
}