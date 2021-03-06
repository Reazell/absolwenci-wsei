using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Commands.ImportFile;
using CareerMonitoring.Infrastructure.Extensions.Aggregate.Interfaces;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace CareerMonitoring.Api.Controllers {
    [Authorize (Policy = "master")]
    public class ImportFileController : ApiUserController {
        private readonly IImportFileAggregate _importFileFactory;
        private readonly IUnregisteredUserService _unregisteredUserService;

        public ImportFileController (IImportFileAggregate importFileFactory,
            IUnregisteredUserService unregisteredUserService) {
            _importFileFactory = importFileFactory;
            _unregisteredUserService = unregisteredUserService;
        }

        [HttpPost ("import")]
        public async Task<IActionResult> ImportFile ([FromForm] ImportFile command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                var fullFileLocation = await _importFileFactory.UploadFileAndGetFullFileLocationAsync (command.File);
                var importDataList = await _importFileFactory.ImportExcelFileAndGetImportDataAsync (fullFileLocation);
                return Json (importDataList);

            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpGet ("unregisteredUsers/{unregisteredUserId}")]
        public async Task<IActionResult> GetUnregisteredUser (int unregisteredUserId) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                var unregisteredUser = await _unregisteredUserService.GetByIdAsync (unregisteredUserId);
                return Json (unregisteredUser);

            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpGet ("unregisteredUsers")]
        public async Task<IActionResult> GetAllUnregisteredUsers () {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                var unregisteredUsers = await _unregisteredUserService.GetAllAsync ();
                return Json (unregisteredUsers);

            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpPost ("unregisteredUsers")]
        public async Task<IActionResult> AddUnregisteredUser ([FromBody] AddUnregisteredUser command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _unregisteredUserService.CreateAsync (command.Name, command.Surname, command.Email);
                return StatusCode (201);

            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpPut ("unregisteredUsers/{id}")]
        public async Task<IActionResult> UpdateUnregisteredUser ([FromBody] UpdateUnregisteredUser command, int id) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _unregisteredUserService.UpdateAsync (id, command.Name, command.Surname, command.Email);
                return StatusCode (200);

            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        [HttpDelete ("unregisteredUsers/{id}")]
        public async Task<IActionResult> DeleteUnregisteredUser (int id) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try {
                await _unregisteredUserService.DeleteAsync (id);
                return StatusCode (202);

            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

    }
}