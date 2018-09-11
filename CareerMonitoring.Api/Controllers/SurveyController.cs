using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Survey;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers
{
    [Authorize]
    public class SurveyController : ApiUserController
    {
        private readonly ISurveyService _surveyService;

        public SurveyController (ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost ("createSurvey")]
        public async Task<IActionResult> CreateSurvey ([FromBody] CreateSurvey command)
        {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try
            {
                await _surveyService.CreateAsync (command.Title);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("multipleChoice/{surveyId}")]
        public async Task<IActionResult> AddMultipleChoiceQuestionToSurvey (int surveyId, [FromBody] ChoiceQuestionToAdd command)
        {
             if (!ModelState.IsValid)
                 return BadRequest (ModelState);
             try
             {
                 await _surveyService.AddMultipleChoiceQuestionAsync (surveyId, command.Content, command.AnswersOptions);
                 return StatusCode(201);
             }
             catch (Exception e)
             {
                 return BadRequest (e.Message);
            }
        }

        [HttpPost ("singleChoice/{surveyId}")]
        public async Task<IActionResult> AddSingleChoiceQuestionToSurvey (int surveyId, [FromBody] ChoiceQuestionToAdd command)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest (ModelState);
            try
            {
                await _surveyService.AddSingleChoiceQuestionAsync (surveyId, command.Content, command.AnswersOptions);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("linearScale/{surveyId}")]
        public async Task<IActionResult> AddLinearScaleQuestionToSurvey (int surveyId, [FromBody] LinearScaleQuestionToAdd command)
        {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try
            {
                await _surveyService.AddLinearScaleQuestionAsync (surveyId, command.Content, command.MinValue, command.MaxValue, command.MinLabel, command.MaxLabel);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("openQuestion/{surveyId}")]
        public async Task<IActionResult> AddOpenQuestionToSurvey (int surveyId, [FromBody] OpenQuestionToAdd command)
        {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try
            {
                await _surveyService.AddOpenQuestionAsync (surveyId, command.Content);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("singleGrid/{surveyId}")]
        public async Task<IActionResult> AddSingleGridQuestionToSurvey (int surveyId, [FromBody] GridQuestionToAdd command)
        {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try
            {
                await _surveyService.AddSingleGridQuestionAsync (surveyId, command.Content, command.Rows, command.Cols);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("multipleGrid/{surveyId}")]
        public async Task<IActionResult> AddMultipleGridQuestionToSurvey (int surveyId, [FromBody] GridQuestionToAdd command)
        {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try
            {
                await _surveyService.AddMultipleGridQuestionAsync (surveyId, command.Content, command.Rows, command.Cols);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest (e.Message);
            }
        }
    }
}