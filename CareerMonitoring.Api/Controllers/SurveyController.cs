using System;
using System.Collections.Generic;
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
        private readonly ISurveyReportService _surveyReportService;

        public SurveyController (ISurveyService surveyService, ISurveyReportService surveyReportService) {
            _surveyService = surveyService;
            _surveyReportService = surveyReportService;
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
            var surveyId = await _surveyService.CreateAsync (command.Title);
            if(command.Questions == null)
                return BadRequest ("Cannot create empty survey");
            foreach (var question in command.Questions) {
                var questionId = await _surveyService.AddQuestionToSurveyAsync(surveyId, question.QuestionPosition,
                    question.Content, question.Select);
                if(question.FieldData == null)
                    return BadRequest ("Question must contain FieldData");
                foreach (var fieldData in question.FieldData) {
                    await AddChoiceOptionsAndRowsAsync (questionId, question.Select, fieldData);
                }
            }

            await _surveyReportService.CreateAsync(surveyId, command.Title);
            return Json(surveyId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSurvey ([FromBody] SurveyToUpdate command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            var surveyId = await _surveyService.UpdateAsync (command.SurveyId, command.Title);
            if(command.Questions == null)
                return BadRequest ("Cannot create empty survey");
            foreach (var question in command.Questions) {
                var questionId = await _surveyService.AddQuestionToSurveyAsync(surveyId, question.QuestionPosition,
                    question.Content, question.Select);
                if(question.FieldData == null)
                    return BadRequest ("Question must contain FieldData");
                foreach (var fieldData in question.FieldData) {
                    await AddChoiceOptionsAndRowsAsync (questionId, question.Select, fieldData);
                }
            }
            await _surveyReportService.UpdateAsync(command.SurveyId, command.Title);
            return StatusCode (200);
        }
        private async Task AddChoiceOptionsAndRowsAsync (int questionId, string select, FieldDataToAdd fieldDataToAdd)
        {
            var fieldDataId = await _surveyService.AddFieldDataToQuestionAsync (questionId,
                fieldDataToAdd.Input,
                fieldDataToAdd.MinValue,
                fieldDataToAdd.MaxValue,
                fieldDataToAdd.MinLabel,
                fieldDataToAdd.MaxLabel);
            if (select == "single-grid" || select == "multiple-grid"){
                await AddRowsAsync(fieldDataToAdd, select, fieldDataId);
                await AddChoiceOptionsAsync(fieldDataToAdd, select, fieldDataId);
            }

            else if (select == "single-choice" || select == "multiple-choice" || select == "dropdown-menu" ||
                     select == "single-grid" || select == "multiple-grid")
                await AddChoiceOptionsAsync(fieldDataToAdd, select, fieldDataId);
            else
                await Task.CompletedTask;
        }
        private async Task AddChoiceOptionsAsync (FieldDataToAdd fieldDataToAdd, string select, int fieldDataId)
        {
            if(fieldDataToAdd.ChoiceOptions != null){
                var counter = 0; //temporary bugfix
                foreach (var choiceOption in fieldDataToAdd.ChoiceOptions)
                {
                    await _surveyService.AddChoiceOptionsAsync(fieldDataId, counter,
                        choiceOption.Value, choiceOption.ViewValue);
                    counter++;
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