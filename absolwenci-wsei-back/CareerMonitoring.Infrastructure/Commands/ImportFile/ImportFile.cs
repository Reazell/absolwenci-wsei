using System.IO;
using Microsoft.AspNetCore.Http;

namespace CareerMonitoring.Infrastructure.Commands.ImportFile {
    public class ImportFile {
        public IFormFile File { get; set; }

    }
}