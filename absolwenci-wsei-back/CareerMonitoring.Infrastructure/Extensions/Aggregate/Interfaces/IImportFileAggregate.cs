using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.DTO.ImportFile;
using Microsoft.AspNetCore.Http;

namespace CareerMonitoring.Infrastructure.Extensions.Aggregate.Interfaces {
    public interface IImportFileAggregate {
        Task<string> UploadFileAndGetFullFileLocationAsync (IFormFile file);
        Task<IEnumerable<UnregisteredUserDto>> ImportExcelFileAndGetImportDataAsync (string fullFileLocation);
        Task<IEnumerable<UnregisteredUserDto>> ImportExcelFileToGroupAndGetImportDataAsync (string fullFileLocation, int groupId);
        
    }
}