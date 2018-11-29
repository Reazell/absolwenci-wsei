using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Account;
using CareerMonitoring.Infrastructure.Commands.ProfileEdition;
using CareerMonitoring.Infrastructure.Extensions.ExceptionHandling;
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

        [Authorize]
        [HttpPut ("accounts/certificate")]
        public async Task<IActionResult> AddCertificate ([FromBody] AddCertificate command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.AddCertificateAsync (UserId, command.Title, command.DateOfReceived);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpGet ("accounts/certificate")]
        public async Task<IActionResult> GetCertificate () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                return Json(await _profileEditionService.GetCertificatesAsync(UserId));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete ("accounts/certificate")]
        public async Task<IActionResult> DeleteCertificate ([FromBody] DeleteCertificate command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.DeleteCertificateAsync(UserId,command.Id);
                return Ok();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/courses")]
        public async Task<IActionResult> AddCourse ([FromBody] AddCourse command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.AddCourseAsync (UserId, command.Name);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }

        }
        
        [Authorize]
        [HttpGet ("accounts/courses")]
        public async Task<IActionResult> GetCourse () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                return Json(await _profileEditionService.GetCoursesAsync(UserId));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete ("accounts/courses")]
        public async Task<IActionResult> DeleteCourse ([FromBody] DeleteCourse command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.DeleteCourseAsync(UserId,command.Id);
                return Ok();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/educations")]
        public async Task<IActionResult> AddEducation ([FromBody] AddEducation command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.AddEducationAsync (UserId, command.Course, command.Year,
                    command.Specialization, command.NameOfUniversity, command.Graduated);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpGet ("accounts/educations")]
        public async Task<IActionResult> GetEducation () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                return Json(await _profileEditionService.GetEducationsAsync(UserId));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete ("accounts/educations")]
        public async Task<IActionResult> DeleteEducation ([FromBody] DeleteEducation command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.DeleteEducationAsync(UserId,command.Id);
                return Ok();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/experiences")]
        public async Task<IActionResult> AddExperience ([FromBody] AddExperience command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.AddExperienceAsync (UserId, command.Position, command.CompanyName,
                    command.Location, command.From, command.To, command.IsCurrentJob);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpGet ("accounts/experiences")]
        public async Task<IActionResult> GetExperience () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                return Json(await _profileEditionService.GetExperiencesAsync(UserId));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete ("accounts/experiences")]
        public async Task<IActionResult> DeleteExperience ([FromBody] DeleteExperience command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.DeleteExperienceAsync(UserId,command.Id);
                return Ok();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/languages")]
        public async Task<IActionResult> AddLanguage ([FromBody] AddLanguage command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.AddLanguageAsync (UserId, command.Name, command.Proficiency);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpGet ("accounts/languages")]
        public async Task<IActionResult> GetLanguage () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                return Json(await _profileEditionService.GetLanguagesAsync(UserId));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete ("accounts/languages")]
        public async Task<IActionResult> DeleteLanguage ([FromBody] DeleteLanguage command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.DeleteLanguageAsync(UserId,command.Id);
                return Ok();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/profileLinks")]
        public async Task<IActionResult> AddProfileLink ([FromBody] AddProfileLink command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.AddProfileLinkAsync (UserId, command.Content);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpGet ("accounts/profileLinks")]
        public async Task<IActionResult> GetProfileLink () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                return Json(await _profileEditionService.GetProfileLinksAsync(UserId));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete ("accounts/profileLinks")]
        public async Task<IActionResult> DeleteProfileLink () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.DeleteProfileLinkAsync(UserId);
                return Ok();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [Authorize]
        [HttpPut ("accounts/skills")]
        public async Task<IActionResult> AddSkills ([FromBody] AddSkill command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.AddSkillAsync (UserId, command.SkillId);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpGet ("accounts/skills")]
        public async Task<IActionResult> GetSkills () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                return Json(await _profileEditionService.GetSkillsAsync(UserId));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete ("accounts/skills")]
        public async Task<IActionResult> DeleteSkills ([FromBody] DeleteSkill command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _profileEditionService.DeleteSkillAsync(UserId,command.Id);
                return Ok();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }
    }
}