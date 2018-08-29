using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Commands.CareerOffice;
using CareerMonitoring.Infrastructure.Commands.Employer;
using CareerMonitoring.Infrastructure.Commands.Graduate;
using CareerMonitoring.Infrastructure.Commands.User;
using CareerMonitoring.Infrastructure.Extension.JWT;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CareerMonitoring.Api.Controllers {
    public class AuthController : ApiUserController {
        private readonly IAuthService _authService;
        private readonly IJWTSettings _jwtSettings;
        private readonly IAccountService _accountService;

        public AuthController (IAuthService authService,
            IJWTSettings jwtSettings,
            IAccountService accountService) {
            _authService = authService;
            _jwtSettings = jwtSettings;
            _accountService = accountService;
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
            return Ok (token);
        }

        [HttpPost ("students")]
        public async Task<IActionResult> RegisterStudent ([FromBody] RegisterStudent command) {
            command.Email = command.Email.ToLowerInvariant ();
            if (await _accountService.ExistsByEmailAsync (command.Email))
                ModelState.AddModelError ("Email", "Email is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterStudentAsync (command.Name, command.Surname, command.Email, command.IndexNumber, command.PhoneNumber, command.Password);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("employers")]
        public async Task<IActionResult> RegisterEmployer ([FromBody] RegisterEmployer command) {
            command.Email = command.Email.ToLowerInvariant ();
            if (await _accountService.ExistsByEmailAsync (command.Email))
                ModelState.AddModelError ("Email", "Email is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterEmployerAsync (command.Name, command.Surname, command.Email, command.PhoneNumber, command.Password,
                    command.CompanyName, command.Location, command.CompanyDescription);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("graduates")]
        public async Task<IActionResult> RegisterGraduate ([FromBody] RegisterGraduate command) {
            command.Email = command.Email.ToLowerInvariant ();
            if (await _accountService.ExistsByEmailAsync (command.Email))
                ModelState.AddModelError ("Email", "Email is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterGraduateAsync (command.Name, command.Surname, command.Email, command.PhoneNumber, command.Password);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("careeroffices")]
        public async Task<IActionResult> RegisterCareerOffice ([FromBody] RegisterCareerOffice command) {
            command.Email = command.Email.ToLowerInvariant ();
            if (await _accountService.ExistsByEmailAsync (command.Email))
                ModelState.AddModelError ("Email", "Email is already taken.");
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterCareerOfficeAsync (command.Name, command.Surname, command.Email, command.PhoneNumber, command.Password);
                return StatusCode (201);
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
    }
}