using CareerMonitoring.Infrastructure.Commands.CareerOffice;
using FluentValidation;

namespace CareerMonitoring.Infrastructure.Validators.CareerOffice {
    public class RegisterCareerOfficeValidator : AbstractValidator<RegisterCareerOffice> {
        public RegisterCareerOfficeValidator () {
            RuleFor (reg => reg.Name)
                .NotNull ()
                .MinimumLength (3)
                .Matches (@"^[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+)*$")
                .WithMessage ("Name should contain only letters with one space between words");
            RuleFor (reg => reg.Surname)
                .NotNull ()
                .MinimumLength (3)
                .Matches (@"^[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+)*$")
                .WithMessage ("Surname should contain only letters with one space between words");
            RuleFor (reg => reg.Email)
                .NotNull ()
                .EmailAddress ()
                .MinimumLength (5);
            RuleFor (reg => reg.PhoneNumber)
                .NotNull ()
                .Matches (@"^\+(?:[0-9]●?){10,10}[0-9]$")
                .WithMessage ("Phone number is invalid.");
            RuleFor (reg => reg.Password)
                .NotNull ()
                .Must (u => !string.IsNullOrEmpty (u) && u.Contains (""))
                .WithMessage ("Password should not contain space")
                .Matches (@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$")
                .WithMessage ("Passoword must consist of 8-50 characters and at least: one number, one upper case, one lower case  and one unique character such as '!#$%&?' ");
        }
    }
}