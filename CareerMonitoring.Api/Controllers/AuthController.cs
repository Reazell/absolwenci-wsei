using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Commands.User;
using CareerMonitoring.Infrastructure.Extension.JWT;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CareerMonitoring.Api.Controllers {
    public class AuthController : ApiUserController {
        private readonly IAuthService _authService;
        private readonly IJWTSettings _jwtSettings;

        public AuthController (IAuthService authService,
            IJWTSettings jwtSettings) {
            _authService = authService;
            _jwtSettings = jwtSettings;
        }

        [HttpPost ("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterStudent command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _authService.RegisterStudentAsync (command.Name, command.Surname, command.Email, command.IndexNumber, command.PhoneNumber, command.Password);
                return StatusCode (201);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
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
            try {
                var account = await _authService.LoginAsync (command.Email, command.Password);
                var token = new TokenDto {
                    Token = await GenerateToken (account, _jwtSettings)
                };
                return Ok (token);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
    }
}