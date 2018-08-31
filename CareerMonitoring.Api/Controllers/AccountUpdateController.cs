using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Account;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers
{
    [Authorize]
    public class AccountUpdateController : ApiUserController
    {
        private readonly IAccountService _accountService;

        public AccountUpdateController (IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AccountUpdate(int id, [FromBody]UpdateAccount command)
        {
            await _accountService.UpdateAsync(id, command.Name, command.Surname, command.Email,
                command.PhoneNumber, command.CompanyName, command.Location, command.CompanyDescription);
            return Json("Account updated");
        }
    }
}