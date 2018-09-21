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
                    await AddChoiceOptionsAndRowsAsync (questionId, question.Select, fieldData);
                }
            }
            return StatusCode (201);
        }

        [HttpPost ("update")]
        public async Task<IActionResult> UpdateSurvey ([FromBody] SurveyToUpdate command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            int surveyId = await _surveyService.UpdateAsync (command.SurveyId, command.Title);
            if(command.Questions == null)
                return BadRequest ("Cannot create empty survey");
            foreach (var question in command.Questions) {
                int questionId = await _surveyService.AddQuestionToSurveyAsync (surveyId, question.QuestionPosition, question.Content, question.Select);
                if(question.FieldData == null)
                    return BadRequest ("Question must contain FieldData");
                foreach (var fieldData in question.FieldData) {
                    await AddChoiceOptionsAndRowsAsync (questionId, question.Select, fieldData);
                }
            }
            return StatusCode (200);
        }
        private async Task AddChoiceOptionsAndRowsAsync (int questionId, string select, FieldDataToAdd fieldDataToAdd)
        {
            int fieldDataId = await _surveyService.AddFieldDataToQuestionAsync (questionId,
                fieldDataToAdd.Input,
                fieldDataToAdd.MinValue,
                fieldDataToAdd.MaxValue,
                fieldDataToAdd.MinLabel,
                fieldDataToAdd.MaxLabel);
            if (select == "single-grid" || select == "multiple-grid")
                await AddRowsAsync(fieldDataToAdd, select, fieldDataId);

            else if(select == "single-choice" || select == "multiple-choice" || select == "dropdown-menu" || select == "single-grid" || select == "multiple-grid")
                await AddChoiceOptionsAsync(fieldDataToAdd, select, fieldDataId);
            else
                await Task.CompletedTask;
        }
        private async Task AddChoiceOptionsAsync (FieldDataToAdd fieldDataToAdd, string select, int fieldDataId)
        {
            if(fieldDataToAdd.ChoiceOptions != null){
                foreach (var choiceOption in fieldDataToAdd.ChoiceOptions)
                {
                    await _surveyService.AddChoiceOptionsAsync (fieldDataId, choiceOption.OptionPosition, choiceOption.Value, choiceOption.ViewValue);
                }
            }
        }

        private async Task AddRowsAsync (FieldDataToAdd fieldDataToAdd, string select, int fieldDataId)
        {
            if(fieldDataToAdd.Rows == null)
                await Task.CompletedTask;
            foreach (var row in fieldDataToAdd.Rows)
            {
                await _surveyService.AddRowAsync (fieldDataId, row.RowPosition, row.Input);
            }
        }

        [HttpDelete ("{surveyId}")]
        public async Task<IActionResult> DeleteSurvey (int surveyId)
        {
            await _surveyService.DeleteAsync(surveyId);
            return StatusCode(200);
        }
    }
}