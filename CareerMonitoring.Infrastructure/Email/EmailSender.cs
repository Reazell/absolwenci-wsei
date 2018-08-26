using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Email.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;

namespace CareerMonitoring.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailConfig _emailConfig;

        public EmailSender(IEmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmailAsync(MimeMessage mimeMessage)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.SmtpPort, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}