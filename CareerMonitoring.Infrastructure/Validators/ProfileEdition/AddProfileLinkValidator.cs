using CareerMonitoring.Infrastructure.Commands.ProfileEdition;
using FluentValidation;

namespace CareerMonitoring.Infrastructure.Validators.ProfileEdition {
    public class AddProfileLinkValidator : AbstractValidator<AddProfileLink> {
        public AddProfileLinkValidator () {
            RuleFor (reg => reg.Content)
                .NotNull ()
                .NotEmpty ()
                .WithMessage ("Content cannot be null or empty.");
        }
    }
}