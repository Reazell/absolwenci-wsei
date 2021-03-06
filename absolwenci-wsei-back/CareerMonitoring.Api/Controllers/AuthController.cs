using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Commands.Account;
using CareerMonitoring.Infrastructure.Commands.CareerOffice;
using CareerMonitoring.Infrastructure.Commands.Master;
using CareerMonitoring.Infrastructure.Commands.User;
using CareerMonitoring.Infrastructure.Extension.JWT;
using CareerMonitoring.Infrastructure.Extension.JWT.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CareerMonitoring.Api.Controllers {
    public class AuthController : ApiUserController {
        private readonly IAuthService _authService;
        private readonly IJWTSettings _jwtSettings;
        private readonly IAccountService _accountService;
        private readonly IMasterService _masterService;


        public AuthController(IAuthService authService, IJWTSettings jwtSettings, IAccountService accountService, IMasterService masterService)
        {
            _authService = authService;
            _jwtSettings = jwtSettings;
            _accountService = accountService;
            _masterService = masterService;
        }

        private async Task<string> GenerateToken (Account account, IJWTSettings jwtSettings) {
            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.NameIdentifier, account.Id.ToString ()),
                new Claim (ClaimTypes.Name, account.Email),
                new Claim (ClaimTypes.Role, account.Role)
                }),
                Issuer = "",
                Expires = DateTime.Now.AddDays (jwtSettings.ExpiryDays),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken (tokenDescriptor);
            return await Task.FromResult (tokenHandler.WriteToken (token));
        }

        [HttpPost ("login")]
        public async Task<IActionResult> Login ([FromBody] SignIn command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            var account = await _authService.LoginAsync (command.Email, command.Password);
            if (account == null)
                return Unauthorized ();
            var token = new TokenDto {
                Token = await GenerateToken (account, _jwtSettings)
            };
            return  Json(new
            {
                LoginData = token, 
                account.Role, 
                account.Name, 
                account.Surname, 
                account.Email, 
                account.PhoneNumber
            });
        }

        [HttpPost ("careerOffices")]
        public async Task<IActionResult> RegisterCareerOffice ([FromBody] RegisterCareerOffice command) {
            command.Email = command.Email.ToLowerInvariant ();
            if (await _accountService.ExistsByEmailAsync (command.Email))
                ModelState.AddModelError ("Email", "Email is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterCareerOfficeAsync (command.Name, command.Surname, command.Email,
                    command.PhoneNumber, command.Password);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("firstMaster")]
        public async Task<IActionResult> RegisterFirstMaster ([FromBody] RegisterMaster command) {
            if(await _masterService.ExistAsync())
                ModelState.AddModelError("exists","first master already exists");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterMasterAsync (command.Name, command.Surname, command.Email,
                    command.PhoneNumber, command.Password);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize (Policy = "master")]
        [HttpPost ("master")]
        public async Task<IActionResult> RegisterMaster ([FromBody] RegisterMaster command) {
            command.Email = command.Email.ToLowerInvariant ();
            if (await _accountService.ExistsByEmailAsync (command.Email))
                ModelState.AddModelError ("Email", "Email is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterMasterAsync (command.Name, command.Surname, command.Email,
                    command.PhoneNumber, command.Password);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpGet ("master")]
        public async Task<IActionResult> ExistsMaster () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try
            {
                return Json(await _masterService.ExistAsync());
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpGet ("activation/{activationKey}")]
        public async Task<IActionResult> AccountActivation (Guid activationKey) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError ("activationKey", "Value of activation key is invalid.");
                return BadRequest (ModelState);
            }
            try {
                await _accountService.ActivateAsync (activationKey);
                return Ok (new { message = "Account was activated" });
            } catch (Exception e) {
                return NotFound (new { message = e.Message });
            }
        }

        [Authorize]
        [HttpPost ("changePassword")]
        public async Task<IActionResult> ChangePassword ([FromBody] ChangePassword command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            var user = await _authService.LoginAsync (UserEmail, command.OldPassword);
            if (user == null)
                return Unauthorized ();
            try {
                await _accountService.UpdatePasswordAsync (user, command.NewPassword);
                return Ok (new { message = "Password was changed." });
            } catch (Exception e) {
                return BadRequest (new { errorMessage = e.Message });
            }
        }

        [HttpPost ("restorePassword")]
        public async Task<IActionResult> RestorePassword ([FromBody] RestorePassword command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            var user = await _accountService.GetActiveByEmailAsync (command.Email, true);
            if (user == null)
                return BadRequest (new { message = "User of given email does not exist." });
            try {
                await _accountService.RestorePasswordAsync (user);
                return Ok (new { message = "The message of password restoring has been sent to given email address" });
            } catch (Exception e) {
                return BadRequest (new { errorMessage = e.Message });
            }
        }

        [HttpPost ("changePasswordByRestoringPassword")]
        public async Task<IActionResult> ChangePasswordByRestoringPassword (
            [FromBody] ChangePasswordByRestoringPassword command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            var account = await _accountService.GetActiveWithAccountRestoringPasswordByTokenAsync (command.Token);
            if (account == null)
                return Unauthorized ();
            try {
                await _accountService.ChangePasswordByRestoringPassword (account.Email, command.Token,
                    command.NewPassword);
                return Ok (new { message = "The password was changed" });
            } catch (Exception e) {
                return NotFound (new { message = e.Message });
            }
        }

    }
}