using CareerMonitoring.Infrastructure.Commands.ProfileEdition;
using FluentValidation;

namespace CareerMonitoring.Infrastructure.Validators.ProfileEdition {
    public class AddEducationValidator : AbstractValidator<AddEducation> {
        public AddEducationValidator () {
            RuleFor (reg => reg.Course)
                .NotNull ()
                .NotEmpty ()
                .MaximumLength (30)
                .MinimumLength (3)
                .WithMessage ("Course cannot be null or empty.");
            RuleFor (reg => reg.Year)
                .NotNull ()
                .NotEmpty ()
                .GreaterThan (0)
                .LessThan (5)
                .WithMessage ("Year cannot be null or empty");
            RuleFor (reg => reg.Specialization)
                .NotEmpty ()
                .MaximumLength (30)
                .MinimumLength (3)
                .WithMessage ("Specialization cannot be null or empty.");
            RuleFor (reg => reg.NameOfUniversity)
                .NotNull ()
                .MinimumLength (3)
                .Matches (@"^[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+)*$")
                .WithMessage ("Name of University should contain only letters with one space between words");
            RuleFor (reg => reg.Graduated)
                .NotNull ()
                .NotEmpty ()
                .WithMessage ("Graduated cannot be empty.");
        }
    }
}