using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.SurveyAnswer;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    //[Authorize]
    public class SurveyAnswerController : ApiUserController {
        private readonly ISurveyAnswerService _surveyAnswerService;

        public SurveyAnswerController (ISurveyAnswerService surveyAnswerService) {
            _surveyAnswerService = surveyAnswerService;
        }

        // [HttpGet ("{surveyId}")]
        // public async Task<IActionResult> GetSurvey (int surveyId)
        // {
        //     var surveyAnswer = await _surveyAnswerService.GetBySurveyIdAsync (surveyId);
        //     return Json(surveyAnswer);
        // }

        // [HttpGet ("surveys")]
        // public async Task<IActionResult> GetAllSurveys ()
        // {
        //     var surveys = await _surveyAnswerService.GetAllAsync ();
        //     return Json (surveys);
        // }

        [HttpPost ("surveys")]
        public async Task<IActionResult> CreateSurvey ([FromBody] SurveyAnswerToAdd command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            int surveyAnswerId = await _surveyAnswerService.CreateAsync (command.SurveyTitle, command.SurveyId);
            foreach (var questionAnswer in command.Questions) {
                int questionAnswerId = await _surveyAnswerService.AddQuestionAnswerToSurveyAnswerAsync (surveyAnswerId, questionAnswer.QuestionPosition, questionAnswer.Content, questionAnswer.Select);
                foreach (var fieldDataAnswer in questionAnswer.FieldData) {
                    int fieldDataAnswerId = await _surveyAnswerService.AddFieldDataAnswerToQuestionAnswerAsync (questionAnswerId,
                        fieldDataAnswer.Input,
                        fieldDataAnswer.MinLabel,
                        fieldDataAnswer.MaxLabel);

                    if (questionAnswer.Select == "single-choice" || questionAnswer.Select == "multiple-choice" || questionAnswer.Select == "dropdown-menu" || questionAnswer.Select == "linear-scale") {
                        foreach (var choiceOption in fieldDataAnswer.ChoiceOptions) {
                            await _surveyAnswerService.AddChoiceOptionsAnswerToFieldDataAnswerAsync (fieldDataAnswerId, choiceOption.OptionPosition, choiceOption.Value, choiceOption.ViewValue);
                        }
                    }
                    if (questionAnswer.Select == "single-grid" || questionAnswer.Select == "multiple-grid") {
                        foreach (var rowAnswer in fieldDataAnswer.Rows) {
                            var rowAnswerId = await _surveyAnswerService.AddRowAnswerAsync (fieldDataAnswerId, rowAnswer.RowPosition, rowAnswer.Input);
                            foreach (var choiceOption in rowAnswer.ChoiceOptions) {
                                await _surveyAnswerService.AddChoiceOptionAnswerToRowAnswerAsync(rowAnswerId, choiceOption.OptionPosition, choiceOption.Value, choiceOption.ViewValue);
                            }
                        }
                    }
                }
            }
            return StatusCode (201);
        }
    }
}