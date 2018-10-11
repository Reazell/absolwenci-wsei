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
                var surveyAnswerId = await _surveyAnswerService.CreateAsync (command.SurveyTitle, command.SurveyId);
                if (command.Questions == null)
                    return BadRequest ("Cannot create empty survey");
                foreach (var questionAnswer in command.Questions) {
                    await AddChoiceOptionsAnswerAndRowAnswerAsync (command.SurveyId, surveyAnswerId, questionAnswer.Select,
                        questionAnswer);
                }

                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        private async Task<IActionResult> AddChoiceOptionsAnswerAndRowAnswerAsync (int surveyId, int surveyAnswerId,
            string select, QuestionAnswerToAdd questionAnswer) {
                var questionAnswerId = await _surveyAnswerService.AddQuestionAnswerToSurveyAnswerAsync (surveyId,
                    surveyAnswerId,
                    questionAnswer.QuestionPosition, questionAnswer.Content, questionAnswer.Select);
                if (questionAnswer.FieldData == null)
                    return BadRequest ("Question must contain FieldData");
                foreach (var fieldDataAnswer in questionAnswer.FieldData) {
                    var fieldDataAnswerId = await _surveyAnswerService.AddFieldDataAnswerToQuestionAnswerAsync (surveyId,
                        questionAnswerId,
                        fieldDataAnswer.Input,
                        fieldDataAnswer.MinLabel,
                        fieldDataAnswer.MaxLabel);

                    if (fieldDataAnswer.ChoiceOptions != null)
                        await AddChoiceOptionsAnswerAsync (surveyId, fieldDataAnswer, questionAnswer.Select,
                            fieldDataAnswerId,
                            questionAnswer);
                    if (fieldDataAnswer.Rows != null)
                        await AddRowsAnswerAsync (surveyId, fieldDataAnswer, questionAnswer.Select, questionAnswer,
                            fieldDataAnswerId);
                }
                return StatusCode (200);
        }

        private async Task AddChoiceOptionsAnswerAsync (int surveyId, FieldDataAnswerToAdd fieldDataAnswer,
            string select, int fieldDataAnswerId, QuestionAnswerToAdd questionAnswer) {
            if (questionAnswer.Select == "single-choice" || questionAnswer.Select == "multiple-choice" ||
                questionAnswer.Select == "dropdown-menu" || questionAnswer.Select == "linear-scale") {
                var counter = 0; //temporary bugfix
                foreach (var choiceOption in fieldDataAnswer.ChoiceOptions) {
                    await _surveyAnswerService.AddChoiceOptionsAnswerToFieldDataAnswerAsync (surveyId, fieldDataAnswerId,
                        counter,
                        choiceOption.Value, choiceOption.ViewValue);
                    counter++;
                }
            }
        }

        private async Task AddRowsAnswerAsync (int surveyId, FieldDataAnswerToAdd fieldDataAnswer,
            string select, QuestionAnswerToAdd questionAnswer, int fieldDataAnswerId) {
            if (fieldDataAnswer.Rows != null) {
                foreach (var rowAnswer in fieldDataAnswer.Rows) {
                    var rowAnswerId = await _surveyAnswerService.AddRowAnswerAsync (fieldDataAnswerId,
                        rowAnswer.RowPosition, rowAnswer.Input);
                    if (rowAnswer.ChoiceOptions != null) {
                        await AddChoiceOptionAnswerToRow (surveyId, rowAnswer, rowAnswerId);
                    }
                }
            }
        }

        private async Task AddChoiceOptionAnswerToRow (int surveyId, RowAnswerToAdd rowAnswer, int rowAnswerId) {
            var counter = 0; //temporary bugfix
            foreach (var choiceOption in rowAnswer.ChoiceOptions) {
                await _surveyAnswerService.AddChoiceOptionAnswerToRowAnswerAsync (surveyId, rowAnswerId,
                    choiceOption.OptionPosition,
                    choiceOption.Value, choiceOption.ViewValue);
                counter++;
            }
            await Task.CompletedTask;
        }
    }
}