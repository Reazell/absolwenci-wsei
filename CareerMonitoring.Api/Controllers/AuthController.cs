using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.User;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    public class AuthController : ApiUserController {
        private readonly IAuthService _authService;

        public AuthController (IAuthService authService) {
            _authService = authService;
        }

        [HttpPost ("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterUser command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterAsync (command.Name, command.Surname, command.Email, command.IndexNumber, command.Password);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
    }
}