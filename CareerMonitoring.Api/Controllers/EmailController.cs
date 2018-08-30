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

        public EmailController (IAccountEmailFactory accountEmailFactory)
        {
            _accountEmailFactory = accountEmailFactory;
        }
        [HttpPost]
        public async Task SendEmailToAll ([FromBody] EmailToSend command)
        {
            await _accountEmailFactory.SendEmailToAllAsync(command.Subject, command.Body);
        }
    }
}