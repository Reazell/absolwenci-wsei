using System.IO;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces {
    public interface IExcelFactory {
        Task ImportExcelFile (FileInfo file);
    }
}