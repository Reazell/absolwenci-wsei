using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Extensions.Email.Interfaces;

namespace CareerMonitoring.Infrastructure.Extensions.Email {
    public class EmailContent : IEmailContent {
        public string ActivationEmail (Guid activationKey) {
            return $"Oto mail wygenerowany automatycznie, potwierdzający Twoją rejestrację w aplikacji <b>Monitorowanie karier</b><br/> Kliknij w" +
                $" <a href=\"http://localhost:4200/api/auth/activation/{activationKey}\">link aktywacyjny</a>, dzięki czemu aktywujesz swoje konto w serwisie.";
        }

        public string RecoveringPasswordEmail (string name, Guid token) {
            return $"Witaj, {name}.Ten mail został wygenerowany automatycznie.</b><br/> Kliknij w" +
                $" <a href=\"http://localhost:4200/api/auth/recoveringPassword/{token}\">link </a>, aby zmienić swoje hasło.";
        }

        public string SurveyEmail (int surveyId, string email) {
            return $"Witaj! Biuro karier WSEI zaprasza do wypełnienia krótkiej ankiety. Aby przejść do ankiety klinkij w ten" +
                $" <a href=\"http://localhost:4200/api/survey/surveys/{surveyId}/{email}\">link</a> .";
        }

    }
}