using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Commands.ImportFile;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace CareerMonitoring.Api.Controllers {
    public class ImportFileController : ApiUserController {
        private readonly IImportFileFactory _importFileFactory;

        public ImportFileController (IImportFileFactory importFileFactory) {
            _importFileFactory = importFileFactory;
        }

        [HttpPost]
        [Route ("import")]
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

    }
}