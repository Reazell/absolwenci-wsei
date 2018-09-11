using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces;
using MimeKit;

namespace CareerMonitoring.Infrastructure.Extensions.Factories
{
    public class SurveyEmailFactory
    {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IEmailFactory _emailFactory;

        public SurveyEmailFactory (IEmailConfiguration emailConfiguration, IEmailFactory emailFactory)
        {
            _emailConfiguration = emailConfiguration;
            _emailFactory = emailFactory;
        }

        public async Task SendSurveyEmailAsync (Account account, int surveyId)
        {
            var message = new MimeMessage ();
            message.From.Add (new MailboxAddress (_emailConfiguration.Name, _emailConfiguration.SmtpUsername));
            message.To.Add (new MailboxAddress (account.Name.ToString (), account.Email.ToString ()));
            message.Subject = "Monitorowanie Karier - ankieta";
            message.Body = new TextPart ("html") {
                Text = $"Witaj, {account.Name}.Biuro karier WSEI zaprasza do wypełnienia krótkiej ankiety.</b><br/> Kliknij w <a href=\"http://localhost:4200/api/survey{surveyId}\">link </a>, aby przejść do strony z ankietą."
            };
            await _emailFactory.SendEmailAsync (message);
        }
    }
}