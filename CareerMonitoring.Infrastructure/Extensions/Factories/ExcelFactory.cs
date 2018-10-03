using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace CareerMonitoring.Infrastructure.Extensions.Factories {
    public class ExcelFactory : IExcelFactory {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ExcelFactory () {

        }
        public Task<string> ImportExcelFile (string fileName) {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            FileInfo file = new FileInfo (Path.Combine (sWebRootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage (file)) {
                StringBuilder sb = new StringBuilder ();
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;
                bool bHeaderRow = true;
                for (int row = 1; row <= rowCount; row++) {
                    for (int col = 1; col <= ColCount; col++) {
                        if (bHeaderRow) {
                            sb.Append (worksheet.Cells[row, col].Value.ToString () + "\t");
                        } else {
                            sb.Append (worksheet.Cells[row, col].Value.ToString () + "\t");
                        }
                    }
                    sb.Append (Environment.NewLine);
                }
            }
            return sb.ToString ();
        }
    }
}