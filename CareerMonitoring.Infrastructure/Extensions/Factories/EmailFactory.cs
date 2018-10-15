using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Extensions.Encryptors.Interfaces;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace CareerMonitoring.Infrastructure.Extensions.Factories {
    public class EmailFactory : IEmailFactory {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IEncryptorFactory _encryptorFactory;

        public EmailFactory (IEmailConfiguration emailConfiguration, IEncryptorFactory encryptorFactory) {
            _emailConfiguration = emailConfiguration;
            _encryptorFactory = encryptorFactory;
        }
        public async Task SendEmailAsync (MimeMessage mimeMessage) {
            using (var client = new SmtpClient ()) {
                await client.ConnectAsync (_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort);
                client.AuthenticationMechanisms.Remove ("XOAUTH2");
                await client.AuthenticateAsync(_emailConfiguration.SmtpUsername,
                   /*  _encryptorFactory.DecryptStringValue*/_emailConfiguration.SmtpPassword);
                await client.SendAsync (mimeMessage);
                await client.DisconnectAsync (true);
            }
        }
    }
}