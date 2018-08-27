using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Infrastructure.Email.Interfaces;
using MimeKit;

namespace CareerMonitoring.Infrastructure.Email
{
    public class ActivationEmailSender : IActivationEmailSender
    {
        private readonly IEmailSender _emailSender;
        private readonly IEmailConfig _emailConfig;

        public ActivationEmailSender (IEmailSender emailSender, IEmailConfig emailConfig)
        {
            _emailSender = emailSender;
            _emailConfig = emailConfig;
        }

        public async Task SendActivationEmailAsync(User user, Guid activationKey)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailConfig.Name, _emailConfig.SmtpUsername));
            message.To.Add(new MailboxAddress(user.Name.ToString(), user.Email.ToString()));
            message.Subject = "Aktywacja w systemie CareerMonitoring";
            message.Body = new TextPart("html") {Text = $"Oto email aktywacyjny dla systemu <b>CareerMonitoring</b><br/>. Aby aktywować swoje konto w serwisie kliknij w <a href=\"http://localhost:5000/api/auth/activation/{activationKey}\">link aktywacyjny</a>"};
            await _emailSender.SendEmailAsync(message);
        }
    }
}