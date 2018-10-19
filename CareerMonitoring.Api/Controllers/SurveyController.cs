using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Survey;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    // [Authorize(Policy = "careerOffice")]
    public class SurveyController : ApiUserController {
        // private readonly ISurveyService _surveyService;
        // private readonly ISurveyReportService _surveyReportService;

        // public SurveyController (ISurveyService surveyService,
        //     ISurveyReportService surveyReportService) {
        //     _surveyService = surveyService;
        //     _surveyReportService = surveyReportService;
        // }

        [HttpGet ("{surveyId}")]
        public async Task<IActionResult> GetSurvey (int surveyId, string email) {
            try{
                var survey = await _surveyService.GetByIdAsync (surveyId);
                return Json (survey);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet ("{surveyId}/{email}/{userId}")]
        public async Task<IActionResult> GetSurveyWithEmail (int surveyId) {
            try{
                var survey = await _surveyService.GetByIdAsync (surveyId);
                return Json (survey);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet ("surveys")]
        public async Task<IActionResult> GetAllSurveys () {
            try{
                var surveys = await _surveyService.GetAllAsync ();
                return Json (surveys);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // // [HttpPost ("surveys")]
        // // public async Task<IActionResult> CreateSurvey ([FromBody] SurveyToAdd command) {
        // //     try{
        // //         if (!ModelState.IsValid)
        // //             return BadRequest (ModelState);
        // //         var surveyId = await _surveyService.CreateSurveyAsync (command);
        // //         await _surveyReportService.CreateAsync(surveyId, command.Title);
        // //         return Json(surveyId);
        // //     }
        // //     catch(Exception e){
        // //         return BadRequest(e.Message);
        // //     }
        // // }

        // // [HttpPut ("surveys")]
        // // public async Task<IActionResult> UpdateSurvey ([FromBody] SurveyToUpdate command) {
        // //     try{
        // //         if (!ModelState.IsValid)
        // //             return BadRequest (ModelState);
        // //         await _surveyService.UpdateSurveyAsync (command);
        // //         await _surveyReportService.UpdateAsync(command.SurveyId, command.Title);
        // //         return StatusCode (200);
        // //     }
        // //     catch(Exception e){
        // //         return BadRequest(e.Message);
        // //     }
        // // }

        // [HttpDelete ("{surveyId}")]
        // public async Task<IActionResult> DeleteSurvey (int surveyId){
        //     try{
        //         await _surveyService.DeleteAsync(surveyId);
        //         return StatusCode(200);
        //     }
        //     catch(Exception e){
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}