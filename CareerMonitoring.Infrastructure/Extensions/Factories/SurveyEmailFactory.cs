using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Extensions.Encryptors.Interfaces;
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
        private readonly IEncryptorFactory _encryptorFactory;
        private readonly IUnregisteredUserRepository _unregisteredUserRepository;

        public SurveyEmailFactory (IEmailConfiguration emailConfiguration,
            IEmailFactory emailFactory,
            IAccountRepository accountRepository,
            ISurveyUserIdentifierService surveyUserIdentifierService,
            IEncryptorFactory encryptorFactory,
            IUnregisteredUserRepository unregisteredUserRepository)
        {
            _surveyUserIdentifierService = surveyUserIdentifierService;
            _encryptorFactory = encryptorFactory;
            _emailConfiguration = emailConfiguration;
            _emailFactory = emailFactory;
            _accountRepository = accountRepository;
            _unregisteredUserRepository = unregisteredUserRepository;
        }

        public async Task SendSurveyEmailAsync (int surveyId) {
            var accounts = await _accountRepository.GetAllAsync ();
            foreach (var account in accounts) {
                if (account.Role != "careerOffice") {
                    var message = new MimeMessage ();
                    message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
                    message.To.Add (new MailboxAddress (account.Name, account.Email));
                    message.Subject = "Monitorowanie karier - ankieta";
                    message.Body = new TextPart ("html") {
                        Text = $"Witaj! Biuro karier WSEI zaprasza do wypełnienia krótkiej ankiety. Aby przejść do ankiety klinkij w ten <a href=\"http://localhost:4200/api/survey/surveys/{surveyId}/{_encryptorFactory.EncryptStringValue(account.Email)}\">link</a> ."
                    };
                    await _emailFactory.SendEmailAsync (message);
                    await _surveyUserIdentifierService.CreateAsync(account.Email, surveyId);
                }
            }
        }

        public async Task SendSurveyEmailToUnregisteredUsersAsync (int surveyId) {
            var unregisteredUsers = await _unregisteredUserRepository.GetAllAsync ();
            foreach (var unregisteredUser in unregisteredUsers) {
                if (unregisteredUser.Role != "careerOffice") {
                    var message = new MimeMessage ();
                    message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
                    message.To.Add (new MailboxAddress (unregisteredUser.Name, unregisteredUser.Email));
                    message.Subject = "Monitorowanie karier - ankieta";
                    message.Body = new TextPart ("html") {
                        Text = $"Witaj! Biuro karier WSEI zaprasza do wypełnienia krótkiej ankiety. Aby przejść do ankiety klinkij w ten <a href=\"http://localhost:4200/api/survey/surveys/{surveyId}\">link</a> ."
                    };
                    await _emailFactory.SendEmailAsync (message);
                }
            }
        }
    }
}