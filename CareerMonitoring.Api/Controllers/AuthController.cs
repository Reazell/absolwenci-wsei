using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Commands.User;
using CareerMonitoring.Infrastructure.Extension.JWT;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CareerMonitoring.Api.Controllers {
    public class AuthController : ApiUserController {
        private readonly IAuthService _authService;
        private readonly IJWTSettings _jwtSettings;
        private readonly IUserService _userService;

        public AuthController (IAuthService authService,
            IJWTSettings jwtSettings, IUserService userService) {
            _authService = authService;
            _jwtSettings = jwtSettings;
            _userService = userService;
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

        private async Task<string> GenerateToken (User user, IJWTSettings jwtSettings) {
            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
                new Claim (ClaimTypes.Name, user.Email),
                new Claim (ClaimTypes.Role, user.Role)
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
        public async Task<IActionResult> Login ([FromBody] SignInUser command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                var user = await _authService.LoginAsync (command.Email, command.Password);
                var token = new TokenDto {
                    Token = await GenerateToken (user, _jwtSettings)
                };
                return Ok (token);
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        [HttpGet ("activation/{activationKey}")]
        public async Task<IActionResult> Activation (Guid activationKey) {
            if (!ModelState.IsValid) {
                return BadRequest (new { errorMessage = "Value of activation key is invalid" });
            }
            try {
                await _userService.ActivateAsync (activationKey);
                return Ok (new { message = "Account was activated" });
            } catch (Exception e) {
                return NotFound (new { message = e.Message });
            }
        }
    }
}