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
        private readonly ISurveyRepository _surveyRepository;

        public SurveyEmailFactory (IEmailConfiguration emailConfiguration,
            IEmailFactory emailFactory,
            IAccountRepository accountRepository,
            ISurveyUserIdentifierService surveyUserIdentifierService,
            IEncryptorFactory encryptorFactory,
            IUnregisteredUserRepository unregisteredUserRepository,
            ISurveyRepository surveyRepository) {
            _surveyUserIdentifierService = surveyUserIdentifierService;
            _encryptorFactory = encryptorFactory;
            _emailConfiguration = emailConfiguration;
            _emailFactory = emailFactory;
            _accountRepository = accountRepository;
            _unregisteredUserRepository = unregisteredUserRepository;
            _surveyRepository = surveyRepository;
        }

        public async Task SendSurveyEmailAsync (int surveyId) {
            var accounts = await _accountRepository.GetAllAsync ();
            var survey = await _surveyRepository.GetByIdAsync(surveyId,false);
            foreach (var account in accounts) {
                if (account.Role != "careerOffice") {
                    var message = new MimeMessage ();
                    message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
                    message.To.Add (new MailboxAddress (account.Name, account.Email));
                    message.Subject = "Monitorowanie karier - ankieta";
                    message.Body = new TextPart ("html") {
                        Text = "<div style=\"padding: 10px;\"> " +
                            "<table width=\"100%\">" +
                            "<tbody>" +
                            "<tr id=\"header\">" +
                            "<td height=\"40\" style=\"background-color: #8bc34a; padding: 25px; text-align: center; color: white;\">" +
                            $"{survey.Title}" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td height=\"30\"></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td style=\"text-align: center;\"><span>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod" +
                            "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation" +
                            "ullamco laboris nisi ut aliquip ex ea commodo consequat.</span></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td height=\"30\"></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<tr>" +
                            "<td style=\"text-align: center; font-weight: 600;\"><span>Zapraszamy do wypełnienia ankiety</span></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td height=\"30\"></td>" +
                            "</tr>" +
                            "<tr style=\"justify-content: center; display: flex;\">" +
                            "<td style=\"display: flex; justify-content: center;\">" +
                            "<div style=\"border-radius: 3px; background-color: #8bc34a; padding: 10px; text-align: center; max-width: 150px;\">" +
                            $"<a style=\"text-decoration: none; color: white; outline: none;\" href=\"http://localhost:4200/api/survey/surveys/{surveyId}/{_encryptorFactory.EncryptStringValue(account.Email)}\">Przejdź do ankiety </a>" +
                            "</div>" +
                            "</td>" +
                            "</tr>" +
                            "<tr></tr>" +
                            "</tbody>" +
                            "</table>" +
                            "</div>"
                    };
                    await _emailFactory.SendEmailAsync (message);
                    await _surveyUserIdentifierService.CreateAsync (account.Email, surveyId);
                }
            }
        }

        public async Task SendSurveyEmailToUnregisteredUsersAsync (int surveyId) {
            var unregisteredUsers = await _unregisteredUserRepository.GetAllAsync ();
            var survey = await _surveyRepository.GetByIdAsync(surveyId,false);
            foreach (var unregisteredUser in unregisteredUsers) {
                if (unregisteredUser.Role != "careerOffice") {
                    var message = new MimeMessage ();
                    message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
                    message.To.Add (new MailboxAddress (unregisteredUser.Name, unregisteredUser.Email));
                    message.Subject = "Monitorowanie karier - ankieta";
                    message.Body = new TextPart ("html") {
                        Text = "<div style=\"padding: 10px;\"> " +
                            "<table width=\"100%\">" +
                            "<tbody>" +
                            "<tr id=\"header\">" +
                            "<td height=\"40\" style=\"background-color: #8bc34a; padding: 25px; text-align: center; color: white;\">" +
                            $"{survey.Title}" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td height=\"30\"></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td style=\"text-align: center;\"><span>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod" +
                            "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation" +
                            "ullamco laboris nisi ut aliquip ex ea commodo consequat.</span></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td height=\"30\"></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<tr>" +
                            "<td style=\"text-align: center; font-weight: 600;\"><span>Zapraszamy do wypełnienia ankiety</span></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td height=\"30\"></td>" +
                            "</tr>" +
                            "<tr style=\"justify-content: center; display: flex;\">" +
                            "<td style=\"display: flex; justify-content: center;\">" +
                            "<div style=\"border-radius: 3px; background-color: #8bc34a; padding: 10px; text-align: center; max-width: 150px;\">" +
                            $"<a style=\"text-decoration: none; color: white; outline: none;\" href=\"http://localhost:4200/api/survey/surveys/{surveyId}/{_encryptorFactory.EncryptStringValue(unregisteredUser.Email)}\">Przejdź do ankiety </a>" +
                            "</div>" +
                            "</div>" +
                            "</td>" +
                            "</tr>" +
                            "<tr></tr>" +
                            "</tbody>" +
                            "</table>" +
                            "</div>"
                    };
                    await _emailFactory.SendEmailAsync (message);
                }
            }
        }
    }
}