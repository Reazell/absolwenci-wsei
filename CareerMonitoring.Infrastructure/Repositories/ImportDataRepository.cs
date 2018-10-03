using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;

namespace CareerMonitoring.Infrastructure.Repositories {
    public class ImportDataRepository : IImportDataRepository {
        private readonly CareerMonitoringContext _context;

        public ImportDataRepository (CareerMonitoringContext context) {
            _context = context;
        }

        public async Task AddAllAsync (IEnumerable<ImportData> importData) {
            await _context.ImportData.AddRangeAsync (importData);
            await _context.SaveChangesAsync ();
        }
    }
}