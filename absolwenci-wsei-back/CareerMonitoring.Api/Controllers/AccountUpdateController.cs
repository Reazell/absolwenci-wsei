using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Account;
using CareerMonitoring.Infrastructure.Extensions.ExceptionHandling;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    public class AccountUpdateController : ApiUserController {
        private readonly IAccountService _accountService;

        public AccountUpdateController (IAccountService accountService) {
            _accountService = accountService;
        }
        
        
        [Authorize]
        [HttpPut ("accounts")]
        public async Task<IActionResult> AccountUpdate ([FromBody] UpdateAccount command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _accountService.UpdateAsync (UserId, command.Name, command.Surname, command.Email,
                    command.PhoneNumber, command.CompanyName, command.Location, command.CompanyDescription);
                return StatusCode (200);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        
//        [HttpGet ("accounts")]
//        public async Task<IActionResult> GetAccounts () {
//            if (!ModelState.IsValid)
//                return BadRequest (ModelState);
//            try
//            {
//                bool exist = await _accountService.ExistsByMaster();
//                return Json(new
//                {
//                    exist
//                });
//            } catch (Exception e) {
//                return BadRequest (e.Message);
//            }
//        }
    }
}