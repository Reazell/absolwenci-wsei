using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Email;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers
{
    [Authorize]
    public class EmailController : ApiUserController
    {
        private readonly IAccountEmailFactory _accountEmailFactory;
        private readonly ISurveyEmailFactory _surveyEmailFactory;

        public EmailController (IAccountEmailFactory accountEmailFactory, ISurveyEmailFactory surveyEmailFactory)
        {
            _accountEmailFactory = accountEmailFactory;
            _surveyEmailFactory = surveyEmailFactory;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailToAll ([FromBody] EmailToSend command)
        {
            await _accountEmailFactory.SendEmailToAllAsync(command.Subject, command.Body);
            return StatusCode(201);
        }

        [HttpPost ("surveyEmails/{surveyId}")]
        public async Task<IActionResult> SendSurveyEmail (int surveyId)
        {
            await _surveyEmailFactory.SendSurveyEmailAsync (surveyId);
            return StatusCode (200);
        }
    }
}