using System.Threading.Tasks;
using MimeKit;

namespace CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces {
    public interface IEmailFactory {
        Task SendEmailAsync (MimeMessage mimeMessage);
    }
}