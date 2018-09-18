using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Survey;
using CareerMonitoring.Infrastructure.Services;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    //[Authorize]
    public class SurveyController : ApiUserController {
        private readonly ISurveyService _surveyService;

        public SurveyController (ISurveyService surveyService) {
            _surveyService = surveyService;
        }

        [HttpGet ("{surveyId}")]
        public async Task<IActionResult> GetSurvey (int surveyId) {
            var survey = await _surveyService.GetByIdAsync (surveyId);
            return Json (survey);
        }

        [HttpGet ("surveys")]
        public async Task<IActionResult> GetAllSurveys () {
            var surveys = await _surveyService.GetAllAsync ();
            return Json (surveys);
        }

        //nie działa -> naprawić
        [HttpPost ("surveys")]
        public async Task<IActionResult> CreateSurvey ([FromBody] SurveyToAdd command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            int surveyId = await _surveyService.CreateAsync (command.Title);
            if(command.Questions == null)
                return BadRequest ("Cannot create empty survey");
            foreach (var question in command.Questions) {
                int questionId = await _surveyService.AddQuestionToSurveyAsync (surveyId, question.QuestionPosition, question.Content, question.Select);
                if(question.FieldData == null)
                    return BadRequest ("Question must contain FieldData");
                foreach (var fieldData in question.FieldData) {
                    int fieldDataId = await _surveyService.AddFieldDataToQuestionAsync (questionId,
                        fieldData.Input,
                        fieldData.MinValue,
                        fieldData.MaxValue,
                        fieldData.MinLabel,
                        fieldData.MaxLabel);
                    if(fieldData.ChoiceOptions == null)
                        goto loop;
                    if (question.Select == "single-choice" || question.Select == "multiple-choice" || question.Select == "dropdown-menu" || question.Select == "single-grid" || question.Select == "multiple-grid") {
                        foreach (var choiceOption in fieldData.ChoiceOptions) {
                            await _surveyService.AddChoiceOptionsAsync (fieldDataId, choiceOption.OptionPosition, choiceOption.Value, choiceOption.ViewValue);
                        }
                    }
                    loop:
                    if(fieldData.Rows == null)
                        continue;
                    if (question.Select == "single-grid" || question.Select == "multiple-grid") {
                        foreach (var row in fieldData.Rows) {
                            await _surveyService.AddRowAsync (fieldDataId, row.RowPosition, row.Input);
                        }
                    }
                }
            }
            return StatusCode (201);
        }

        [HttpPut ("update")]
        public async Task<IActionResult> UpdateSurvey ([FromBody] SurveyToUpdate command)
        {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            int surveyId = await _surveyService.UpdateAsync (command.SurveyId, command.Title);
            if(command.Questions == null)
                return BadRequest ("No questions to add");
            foreach (var question in command.Questions) {
                int questionId = await _surveyService.UpdateQuestionForSurveyAsync (surveyId, question.QuestionPosition, question.Content, question.Select);
                if(question.FieldData == null)
                    return BadRequest ("Question must contain FieldData");
                foreach (var fieldData in question.FieldData) {
                    int fieldDataId = await _surveyService.UpdateFieldDataForQuestionAsync (questionId,
                        fieldData.Input,
                        fieldData.MinValue,
                        fieldData.MaxValue,
                        fieldData.MinLabel,
                        fieldData.MaxLabel);
                    if(fieldData.ChoiceOptions == null)
                        goto loop;
                    if (question.Select == "single-choice" || question.Select == "multiple-choice" || question.Select == "dropdown-menu" || question.Select == "single-grid" || question.Select == "multiple-grid") {
                        foreach (var choiceOption in fieldData.ChoiceOptions) {
                            await _surveyService.UpdateChoiceOptionsAsync (fieldDataId, choiceOption.OptionPosition, choiceOption.Value, choiceOption.ViewValue);
                        }
                    }
                    loop:
                    if(fieldData.Rows == null)
                        continue;
                    if (question.Select == "single-grid" || question.Select == "multiple-grid") {
                        foreach (var row in fieldData.Rows) {
                            await _surveyService.UpdateRowAsync (fieldDataId, row.RowPosition, row.Input);
                        }
                    }
                }
            }
            return StatusCode (201);
        }

        [HttpDelete ("{surveyId}")]
        public async Task<IActionResult> DeleteSurvey (int surveyId)
        {
            await _surveyService.DeleteAsync(surveyId);
            return StatusCode(200);
        }
    }
}