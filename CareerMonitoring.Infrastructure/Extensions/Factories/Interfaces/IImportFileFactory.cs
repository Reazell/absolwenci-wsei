using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.DTO.ImportFile;
using Microsoft.AspNetCore.Http;

namespace CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces {
    public interface IImportFileFactory {
        Task<string> UploadFileAndGetFullFileLocationAsync (IFormFile file);
        Task<IEnumerable<ImportDataDto>> ImportExcelFileAndGetImportDataAsync (string fullFileLocation);
    }
}