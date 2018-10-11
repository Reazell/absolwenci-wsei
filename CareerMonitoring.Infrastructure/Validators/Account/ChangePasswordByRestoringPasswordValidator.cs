using CareerMonitoring.Infrastructure.Commands.Account;
using FluentValidation;

namespace CareerMonitoring.Infrastructure.Validators.Account {
    public class ChangePasswordByRestoringPasswordValidator : AbstractValidator<ChangePasswordByRestoringPassword> {
        public ChangePasswordByRestoringPasswordValidator () {
            // RuleFor (reg => reg.Email)
            //     .EmailAddress ()
            //     .MinimumLength (5)
            //     .MaximumLength (150)
            //     .NotNull ();
            RuleFor (reg => reg.NewPassword)
                .NotNull ()
                .NotEmpty ()
                .MaximumLength (50)
                .Must (u => !string.IsNullOrWhiteSpace (u) && !u.Contains (" "))
                .WithMessage ("Password should not contain space")
                .Matches (@"^(?=.*\d)(?=.*[^\d]).{6,30}$")
                .WithMessage ("Passoword must consist of 6-30 characters and at least one number");
        }
    }
}