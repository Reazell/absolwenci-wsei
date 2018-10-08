using CareerMonitoring.Infrastructure.Commands.ProfileEdition;
using FluentValidation;

namespace CareerMonitoring.Infrastructure.Validators.ProfileEdition {
    public class AddCourseValidator : AbstractValidator<AddCourse> {
        public AddCourseValidator () {
            RuleFor (reg => reg.Name)
                .NotNull ().WithMessage ("Title cannot be null.")
                .NotEmpty ().WithMessage ("Title cannot be empty");
        }
    }
}