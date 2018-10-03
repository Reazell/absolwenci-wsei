using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces {
    public interface IExcelFactory {
        Task<string> ImportExcelFile (string fileName);
    }
}