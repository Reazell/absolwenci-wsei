using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces
{
    public interface ISurveyEmailFactory
    {
        Task SendSurveyEmailAsync ();
    }
}