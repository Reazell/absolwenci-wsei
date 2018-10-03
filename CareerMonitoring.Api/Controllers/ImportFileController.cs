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
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IExcelFactory _excelFactory;
        private readonly IImportDataRepository _importDataRepository;

        public ImportFileController (IHostingEnvironment hostingEnvironment,
            IExcelFactory excelFactory,
            IImportDataRepository importDataRepository) {
            _hostingEnvironment = hostingEnvironment;
            _excelFactory = excelFactory;
            _importDataRepository = importDataRepository;
        }

        [HttpPost]
        [Route ("import")]
        public async Task<IActionResult> ImportFile ([FromForm] ImportFile command) {
            try {
                string rootFolder = _hostingEnvironment.WebRootPath;
                string fileName = command.File.FileName;
                FileInfo file = new FileInfo (Path.Combine (rootFolder, fileName));
                // await _excelFactory.ImportExcelFile (file);

                using (ExcelPackage package = new ExcelPackage (file)) {
                    var workSheet = package.Workbook.Worksheets[1];
                    int totalRows = workSheet.Dimension.Rows;

                    List<ImportData> importDataList = new List<ImportData> ();

                    for (int i = 1; i <= totalRows; i++) {
                        importDataList.Add (new ImportData {
                            Name = workSheet.Cells[i, 1].Value.ToString (),
                                Surname = workSheet.Cells[i, 2].Value.ToString (),
                                Email = workSheet.Cells[i, 3].Value.ToString ().ToLowerInvariant ()
                        });
                    }
                    await _importDataRepository.AddAllAsync (importDataList);
                    return Json (importDataList);
                }
                // return Ok (new { message = "Your file was uploaded successfully." });
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        // [HttpGet]
        // [Route ("import")]
        // public async Task<IActionResult> ImportFile () {
        //     try {
        //         string rootFolder = _hostingEnvironment.WebRootPath;
        //         string fileName = @"ImportData.xlsx";
        //         FileInfo file = new FileInfo (Path.Combine (rootFolder, fileName));
        //         // await _excelFactory.ImportExcelFile (file);

        //         using (ExcelPackage package = new ExcelPackage (file)) {
        //             var workSheet = package.Workbook.Worksheets[1];
        //             int totalRows = workSheet.Dimension.Rows;

        //             List<ImportData> importDataList = new List<ImportData> ();

        //             for (int i = 1; i <= totalRows; i++) {
        //                 importDataList.Add (new ImportData {
        //                     Name = workSheet.Cells[i, 1].Value.ToString (),
        //                         Surname = workSheet.Cells[i, 2].Value.ToString (),
        //                         Email = workSheet.Cells[i, 3].Value.ToString ().ToLowerInvariant ()
        //                 });
        //             }
        //             await _importDataRepository.AddAllAsync (importDataList);
        //             return Json (importDataList);
        //         }
        //         // return Ok (new { message = "Your file was uploaded successfully." });
        //     } catch (Exception e) {
        //         return BadRequest (e.Message);
        //     }
        // }
    }
}