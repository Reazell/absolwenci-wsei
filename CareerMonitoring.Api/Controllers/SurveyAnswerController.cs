using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.SurveyAnswer;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    //[Authorize]
    public class SurveyAnswerController : ApiUserController {
        private readonly ISurveyAnswerService _surveyAnswerService;

        public SurveyAnswerController(ISurveyAnswerService surveyAnswerService)
        {
            _surveyAnswerService = surveyAnswerService;
        }

        [HttpPost ("surveys")]
        public async Task<IActionResult> CreateSurveyAnswer ([FromBody] SurveyAnswerToAdd command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            var surveyAnswerId = await _surveyAnswerService.CreateAsync (command.SurveyTitle, command.SurveyId);
            if (command.Questions == null)
                return BadRequest ("Cannot create empty survey");
            foreach (var questionAnswer in command.Questions) {
                await AddChoiceOptionsAnswerAndRowAnswerAsync(command.SurveyId, surveyAnswerId, questionAnswer.Select,
                    questionAnswer);
            }

            return StatusCode (201);
        }

        private async Task<IActionResult> AddChoiceOptionsAnswerAndRowAnswerAsync (int surveyId, int surveyAnswerId,
            string select, QuestionAnswerToAdd questionAnswer) {
            var questionAnswerId = await _surveyAnswerService.AddQuestionAnswerToSurveyAnswerAsync (surveyAnswerId,
                questionAnswer.QuestionPosition, questionAnswer.Content, questionAnswer.Select);
            if (questionAnswer.FieldData == null)
                return BadRequest ("Question must contain FieldData");
            foreach (var fieldDataAnswer in questionAnswer.FieldData) {
                var fieldDataAnswerId = await _surveyAnswerService.AddFieldDataAnswerToQuestionAnswerAsync(surveyId,
                    questionAnswerId,
                    fieldDataAnswer.Input,
                    fieldDataAnswer.MinLabel,
                    fieldDataAnswer.MaxLabel);

                if (fieldDataAnswer.ChoiceOptions != null)
                    await AddChoiceOptionsAnswerAsync(fieldDataAnswer, questionAnswer.Select, fieldDataAnswerId,
                        questionAnswer);
                if (fieldDataAnswer.Rows != null)
                    await AddRowsAnswerAsync(fieldDataAnswer, questionAnswer.Select, questionAnswer, fieldDataAnswerId);
            }
            return StatusCode (200);
        }

        private async Task AddChoiceOptionsAnswerAsync (FieldDataAnswerToAdd fieldDataAnswer,
            string select, int fieldDataAnswerId, QuestionAnswerToAdd questionAnswer) {
            if (questionAnswer.Select == "single-choice" || questionAnswer.Select == "multiple-choice" ||
                questionAnswer.Select == "dropdown-menu" || questionAnswer.Select == "linear-scale") {
                var counter = 0; //temporary bugfix
                foreach (var choiceOption in fieldDataAnswer.ChoiceOptions) {
                    await _surveyAnswerService.AddChoiceOptionsAnswerToFieldDataAnswerAsync (fieldDataAnswerId,
                        counter,
                        choiceOption.Value, choiceOption.ViewValue);
                    counter++;
                }
            }
        }

        private async Task AddRowsAnswerAsync (FieldDataAnswerToAdd fieldDataAnswer,
            string select, QuestionAnswerToAdd questionAnswer, int fieldDataAnswerId) {
            if (fieldDataAnswer.Rows != null) {
                foreach (var rowAnswer in fieldDataAnswer.Rows) {
                    var rowAnswerId = await _surveyAnswerService.AddRowAnswerAsync(fieldDataAnswerId,
                        rowAnswer.RowPosition, rowAnswer.Input);
                    if (rowAnswer.ChoiceOptions != null) {
                        await AddChoiceOptionAnswerToRow(rowAnswer, rowAnswerId);
                    }
                }
            }
        }

        private async Task AddChoiceOptionAnswerToRow (RowAnswerToAdd rowAnswer, int rowAnswerId) {
            var counter = 0; //temporary bugfix
            foreach (var choiceOption in rowAnswer.ChoiceOptions) {
                await _surveyAnswerService.AddChoiceOptionAnswerToRowAnswerAsync(rowAnswerId,
                    choiceOption.OptionPosition,
                    choiceOption.Value, choiceOption.ViewValue);
                counter++;
            }
            await Task.CompletedTask;
        }
    }
}