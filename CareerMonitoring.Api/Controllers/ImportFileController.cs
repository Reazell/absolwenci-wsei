using System.IO;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers {
    public class ImportFileController : ApiUserController {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IExcelFactory _excelFactory;

        public ImportFileController (IHostingEnvironment hostingEnvironment,
            IExcelFactory excelFactory) {
            _hostingEnvironment = hostingEnvironment;
            _excelFactory = excelFactory;
        }

        [HttpPost]
        [Route ("import")]
        public async Task<IActionResult> ImportFile () {
            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = @"ImportData.xlsx";
            FileInfo file = new FileInfo (Path.Combine (rootFolder, fileName));
            await _excelFactory.ImportExcelFile (file);
            return Ok (new { message = "Your file was uploaded successfully." });
        }
    }
}