using System;
using CareerMonitoring.Infrastructure.Commands.ImportFile;
using FluentValidation;

namespace CareerMonitoring.Infrastructure.Validators.ImportFile {
    public class UpdateUnregisteredUserValidator : AbstractValidator<UpdateUnregisteredUser> {
        public UpdateUnregisteredUserValidator () {
            RuleFor (reg => reg.Name)
                .MinimumLength (3)
                .Matches (@"^[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+)*$")
                .WithMessage ("Name should contain only letters with one space between words.");
            RuleFor (reg => reg.Surname)
                .MinimumLength (3)
                .Matches (@"^[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+(\s{1}[a-zA-ZàáąâäãåąčććęęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšśžÀÁÂÄÃÅĄČĆĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'-]+)*$")
                .WithMessage ("Surname should contain only letters with one space between words.");
            RuleFor (reg => reg.Email)
                .EmailAddress ()
                .MinimumLength (5);
        }
    }
}