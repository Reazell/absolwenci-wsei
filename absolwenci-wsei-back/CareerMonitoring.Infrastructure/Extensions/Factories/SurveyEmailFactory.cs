using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Extensions.Email.Interfaces;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using MimeKit;

namespace CareerMonitoring.Infrastructure.Extensions.Factories {
    public class SurveyEmailFactory : ISurveyEmailFactory {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IEmailFactory _emailFactory;
        private readonly IAccountRepository _accountRepository;
        private readonly ISurveyUserIdentifierService _surveyUserIdentifierService;
        private readonly IUnregisteredUserRepository _unregisteredUserRepository;
        private readonly IEmailContent _emailContent;

        public SurveyEmailFactory (IEmailConfiguration emailConfiguration,
            IEmailFactory emailFactory,
            IAccountRepository accountRepository,
            ISurveyUserIdentifierService surveyUserIdentifierService,
            IUnregisteredUserRepository unregisteredUserRepository,
            IEmailContent emailContent) {
            _surveyUserIdentifierService = surveyUserIdentifierService;
            _emailConfiguration = emailConfiguration;
            _emailFactory = emailFactory;
            _accountRepository = accountRepository;
            _unregisteredUserRepository = unregisteredUserRepository;
            _emailContent = emailContent;
        }

        public async Task SendSurveyEmailAsync (int surveyId) {
            var accounts = await _accountRepository.GetAllAsync ();
            List<Account> accountsToIdentify = new List<Account> ();
            foreach (var account in accounts) {
                if (account.Role != "careerOffice") {
                    accountsToIdentify.Add (account);
                    var message = new MimeMessage ();
                    message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
                    message.To.Add (new MailboxAddress (account.Name, account.Email));
                    message.Subject = "Monitorowanie karier - ankieta";
                    message.Body = new TextPart ("html") {
                        Text = _emailContent.SurveyEmail (surveyId, CalculateEmailHash(account.Email))
                    };
                    await _emailFactory.SendEmailAsync (message);
                }
            }
            foreach (var accountToIdentify in accountsToIdentify)
            {
                await _surveyUserIdentifierService.CreateAsync(accountToIdentify.Email, surveyId);
            }
        }

        public async Task SendSurveyEmailToUnregisteredUsersAsync (int surveyId) {
            var unregisteredUsers = await _unregisteredUserRepository.GetAllAsync ();
            List<UnregisteredUser> unregisteredUsersToIdentify = new List<UnregisteredUser> ();
            foreach (var unregisteredUser in unregisteredUsers) {
                if (unregisteredUser.Role != "careerOffice") {
                    unregisteredUsersToIdentify.Add (unregisteredUser);
                    var message = new MimeMessage ();
                    message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
                    message.To.Add (new MailboxAddress (unregisteredUser.Name, unregisteredUser.Email));
                    message.Subject = "Monitorowanie karier - ankieta";
                    message.Body = new TextPart ("html") {
                        Text = _emailContent.SurveyEmail (surveyId, CalculateEmailHash(unregisteredUser.Email))
                    };
                    await _emailFactory.SendEmailAsync (message);
                }
            }
            foreach (var unregisteredUserToIdentify in unregisteredUsersToIdentify)
            {
                await _surveyUserIdentifierService.CreateAsync(unregisteredUserToIdentify.Email, surveyId);
            }
        }

        public string CalculateEmailHash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}