using Microsoft.AspNetCore.Http;

namespace CareerMonitoring.Infrastructure.Commands.ImportFile {
    public class ImportFile {
        public string FileName { get; set; }
        public IFormFile File { get; set; }

    }
}