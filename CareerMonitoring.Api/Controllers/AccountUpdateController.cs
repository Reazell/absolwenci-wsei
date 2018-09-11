using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Account;
using CareerMonitoring.Infrastructure.Commands.ProfileEdition;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    [Authorize]
    public class AccountUpdateController : ApiUserController {
        private readonly IAccountService _accountService;
        private readonly IProfileEditionService _profileEditionService;

        public AccountUpdateController (IAccountService accountService,
            IProfileEditionService profileEditionService) {
            _accountService = accountService;
            _profileEditionService = profileEditionService;
        }

        [HttpPut ("accounts/{id}")]
        public async Task<IActionResult> AccountUpdate (int id, [FromBody] UpdateAccount command) {
            await _accountService.UpdateAsync (id, command.Name, command.Surname, command.Email,
                command.PhoneNumber, command.CompanyName, command.Location, command.CompanyDescription);
            return Json ("Account updated");
        }

        [Authorize]
        [HttpPut ("accounts/certificate")]
        public async Task<IActionResult> AddCertificate ([FromBody] AddCertificate command) {
            try {
                await _profileEditionService.AddCertificateAsync (UserId, command.Title, command.DateOfReceived);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/courses")]
        public async Task<IActionResult> AddCourse ([FromBody] AddCourse command) {
            try {
                await _profileEditionService.AddCourseAsync (UserId, command.Name);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }

        }

        [Authorize]
        [HttpPut ("accounts/educations")]
        public async Task<IActionResult> AddEducation ([FromBody] AddEducation command) {
            try {
                await _profileEditionService.AddEducationAsync (UserId, command.Course, command.Year,
                    command.Specialization, command.NameOfUniversity, command.Graduated);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/experiences")]
        public async Task<IActionResult> AddExperience ([FromBody] AddExperience command) {
            try {
                await _profileEditionService.AddExperienceAsync (UserId, command.Position, command.CompanyName,
                    command.Location, command.From, command.To, command.IsCurrentJob);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/profileLinks")]
        public async Task<IActionResult> AddProfileLink ([FromBody] AddProfileLink command) {
            try {
                await _profileEditionService.AddProfileLinkAsync (UserId, command.Content);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
    }
}