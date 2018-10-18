using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Email;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers
{
    // [Authorize(Policy = "careerOffice")]
    public class EmailController : ApiUserController
    {
        private readonly IAccountEmailFactory _accountEmailFactory;
        private readonly ISurveyEmailFactory _surveyEmailFactory;
        private readonly ISurveyService _surveyService;

        public EmailController(IAccountEmailFactory accountEmailFactory, ISurveyEmailFactory surveyEmailFactory, ISurveyService surveyService)
        {
            _accountEmailFactory = accountEmailFactory;
            _surveyEmailFactory = surveyEmailFactory;
            _surveyService = surveyService;
        }

        [HttpPost("emails")]
        public async Task<IActionResult> SendEmailToAll([FromBody] EmailToSend command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _accountEmailFactory.SendEmailToAllAsync(command.Subject, command.Body);
                await _accountEmailFactory.SendEmailToAllUnregisteredAsync(command.Subject, command.Body);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("survey-emails/{surveyTemplateId}")]
        public async Task<IActionResult> SendSurveyEmail(int surveyTemplateId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {

                var surveyId = _surveyService.CreateSurveyAsync(surveyTemplateId).Result;
                await _surveyEmailFactory.SendSurveyEmailAsync(surveyId);
                await _surveyEmailFactory.SendSurveyEmailToUnregisteredUsersAsync(surveyId);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}