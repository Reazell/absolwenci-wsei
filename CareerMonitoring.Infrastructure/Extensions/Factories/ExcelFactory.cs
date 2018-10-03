using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using OfficeOpenXml;
// using EPPlus.Core;

namespace CareerMonitoring.Infrastructure.Extensions.Factories {
    public class ExcelFactory : IExcelFactory {
        private readonly IImportDataRepository _importDataRepository;
        public ExcelFactory (IImportDataRepository importDataRepository) {
            _importDataRepository = importDataRepository;
        }

        public async Task ImportExcelFile (FileInfo file) {

            using (ExcelPackage package = new ExcelPackage (file)) {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["ImportData"];
                int totalRows = workSheet.Dimension.Rows;

                List<ImportData> importDataList = new List<ImportData> ();

                for (int i = 2; i <= totalRows; i++) {
                    importDataList.Add (new ImportData {
                        Name = workSheet.Cells[i, 1].Value.ToString (),
                            Surname = workSheet.Cells[i, 2].Value.ToString (),
                            Email = workSheet.Cells[i, 3].Value.ToString ().ToLowerInvariant ()
                    });
                }
                await _importDataRepository.AddAllAsync (importDataList);
            }
        }
    }
}