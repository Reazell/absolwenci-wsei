using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using MimeKit;

namespace CareerMonitoring.Infrastructure.Extensions.Factories {
    public class AccountEmailFactory : IAccountEmailFactory {
        private readonly IEmailFactory _emailFactory;
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IAccountRepository _accountRepository;

        public AccountEmailFactory (IEmailFactory emailFactory, IEmailConfiguration emailConfiguration, IAccountRepository accountRepository) {
            _emailFactory = emailFactory;
            _emailConfiguration = emailConfiguration;
            _accountRepository = accountRepository;
        }

        public async Task SendActivationEmailAsync (Account account, Guid activationKey) {
            var message = new MimeMessage ();
            message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
            message.To.Add (new MailboxAddress (account.Name, account.Email));
            message.Subject = "Monitorowanie karier - aktywacja konta.";
            message.Body = new TextPart ("html") {
                Text = $"Oto mail wygenerowany automatycznie, potwierdzający Twoją rejestrację w aplikacji <b>Monitorowanie karier</b><br/> Kliknij w <a href=\"http://localhost:4200/api/auth/activation/{activationKey}\">link aktywacyjny</a>, dzięki czemu aktywujesz swoje konto w serwisie."
            };
            await _emailFactory.SendEmailAsync (message);
        }

        public async Task SendRecoveringPasswordEmailAsync (Account account, Guid token) {
            var message = new MimeMessage ();
            message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
            message.To.Add (new MailboxAddress (account.Name.ToString (), account.Email.ToString ()));
            message.Subject = "Monitorowanie Karier - przywracanie hasla";
            message.Body = new TextPart ("html") {
                Text = $"Witaj, {account.Name}.Ten mail został wygenerowany automatycznie.</b><br/> Kliknij w <a href=\"http://localhost:5000/api/auth/recoveringPassword/{token}\">link </a>, aby zmienić swoje hasło."
            };
            await _emailFactory.SendEmailAsync (message);
        }

        public async Task SendEmailToAllAsync (string subject, string body)
        {
            var accounts = await _accountRepository.GetAllAsync();
            foreach(var account in accounts)
            {
                if(account.Role != "careerOffice"){
                    var message = new MimeMessage ();
                    message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
                    message.To.Add (new MailboxAddress (account.Name, account.Email));
                    message.Subject = subject;
                    message.Body = new TextPart ("html") {
                        Text = body
                    };
                    await _emailFactory.SendEmailAsync (message);
                }
            }
        }
    }
}