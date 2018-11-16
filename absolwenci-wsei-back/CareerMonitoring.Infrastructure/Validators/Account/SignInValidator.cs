using CareerMonitoring.Infrastructure.Commands.User;
using FluentValidation;

namespace CareerMonitoring.Infrastructure.Validators.User {
    public class SignInValidator : AbstractValidator<SignIn> {
        public SignInValidator () {
            RuleFor (reg => reg.Email)
                .NotNull ()
                .EmailAddress ()
                .MinimumLength (5);
            RuleFor (reg => reg.Password)
                .NotNull ()
                .Must (u => !string.IsNullOrEmpty (u) && u.Contains (""))
                .WithMessage ("Password should not contain space")
                .Matches (@"^(?=.*\d)(?=.*[^\d]).{6,30}$")
                .WithMessage ("Passoword must consist of 6-30 characters and at least one number");
        }
    }

}