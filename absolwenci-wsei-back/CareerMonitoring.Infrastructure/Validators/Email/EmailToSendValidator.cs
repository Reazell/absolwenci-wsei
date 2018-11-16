using CareerMonitoring.Infrastructure.Commands.Email;
using FluentValidation;

namespace CareerMonitoring.Infrastructure.Validators.Email
{
    public class EmailToSendValidator : AbstractValidator<EmailToSend>
    {
        public EmailToSendValidator () {
            RuleFor (reg => reg.Subject)
                .NotNull ()
                .MinimumLength (1);
            RuleFor (reg => reg.Body)
                .NotNull ()
                .MinimumLength (3);
        }
    }
}