using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.DTO.ImportFile;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace CareerMonitoring.Infrastructure.Extensions.Factories {
    public class ImportFileFactory : IImportFileFactory {
        private readonly IImportDataRepository _importDataRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public ImportFileFactory (IImportDataRepository importDataRepository,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper) {
            _importDataRepository = importDataRepository;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public async Task<string> UploadFileAndGetFullFileLocationAsync (IFormFile file) {
            if (file == null && file.Length < 0)
                throw new Exception ("File not selected");

            var path = Path.Combine (_hostingEnvironment.WebRootPath, "uploads", file.FileName).ToLower ();

            if (!Directory.Exists (path)) {
                Directory.CreateDirectory (path);
            }

            string fullFileLocation = Path.Combine (path, file.FileName).ToLower ();

            using (var fileStream = new FileStream (fullFileLocation, FileMode.Create)) {
                await file.CopyToAsync (fileStream);
            }
            return fullFileLocation;
        }

        public async Task<IEnumerable<ImportDataDto>> ImportExcelFileAndGetImportDataAsync (string fullFileLocation) {
            FileInfo fileInfo = new FileInfo (fullFileLocation);
            List<ImportDataDto> importDataListDto = new List<ImportDataDto> ();

            using (ExcelPackage package = new ExcelPackage (fileInfo)) {
                var workSheet = package.Workbook.Worksheets[1];
                int totalRows = workSheet.Dimension.Rows;

                List<ImportData> importDataList = new List<ImportData> ();

                for (int i = 2; i <= totalRows; i++) {
                    var importData = new ImportData ();
                    importData.SetName (workSheet.Cells[i, 1].Value.ToString ());
                    importData.SetSurname (workSheet.Cells[i, 2].Value.ToString ());
                    importData.SetCourse (workSheet.Cells[i, 3].Value.ToString ());
                    importData.SetDateOfCompletion (Convert.ToDateTime (workSheet.Cells[i, 4].Value.ToString ()));
                    importData.SetTypeOfStudy (workSheet.Cells[i, 5].Value.ToString ());
                    importData.SetEmail (workSheet.Cells[i, 6].Value.ToString ().ToLowerInvariant ());
                    importDataList.Add (importData);

                    importDataListDto.Add (_mapper.Map<ImportDataDto> (importData));
                }

                await _importDataRepository.AddAllAsync (importDataList);
            }
            return importDataListDto;
        }

    }
}