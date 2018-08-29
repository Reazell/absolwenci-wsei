using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Email.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailConfig _emailConfig;

        public EmailSender(IEmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmailAsync (MimeMessage mimeMessage)
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

        public async Task SendEmailToAllAsync (IEnumerable<User> Users)
        {
            foreach(var user in Users)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_emailConfig.Name, _emailConfig.SmtpUsername));
                message.To.Add(new MailboxAddress(user.Name.ToString(), user.Email.ToString()));
                message.Subject = "mail";
                message.Body = new TextPart("html") {Text = "mail"};
                await SendEmailAsync(message);
            }
        }
    }
}