using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IImportDataRepository {
        Task AddAllAsync (IEnumerable<ImportData> importData);
    }
}