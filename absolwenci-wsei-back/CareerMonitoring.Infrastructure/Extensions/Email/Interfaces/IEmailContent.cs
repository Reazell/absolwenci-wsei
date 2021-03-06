using System;
using System.Threading.Tasks;

namespace CareerMonitoring.Infrastructure.Extensions.Email.Interfaces {
    public interface IEmailContent {
        string ActivationEmail (Guid activationKey);
        string RecoveringPasswordEmail (string name, Guid token);
        string SurveyEmail (int surveyId, string email);
    }
}