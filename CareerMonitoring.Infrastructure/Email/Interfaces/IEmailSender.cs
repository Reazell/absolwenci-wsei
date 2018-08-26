using System.Threading.Tasks;
using MimeKit;

namespace CareerMonitoring.Infrastructure.Email.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(MimeMessage mimeMessage);
    }
}