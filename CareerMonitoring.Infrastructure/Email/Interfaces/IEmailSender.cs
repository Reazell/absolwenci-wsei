using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using MimeKit;

namespace CareerMonitoring.Infrastructure.Email.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(MimeMessage mimeMessage);
        //Task SendEmailToAllAsync(IEnumerable<User> Users);
    }
}