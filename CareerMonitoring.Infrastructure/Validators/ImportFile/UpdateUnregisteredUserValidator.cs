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
            RuleFor (reg => reg.Course)
                .MaximumLength (50)
                .MinimumLength (3)
                .WithMessage ("Course cannot be null or empty.");
            //RuleFor (reg => reg.DateOfCompletion)
                //.LessThan (p => DateTime.Now)
                //.WithMessage ("Date of completion cannot be greater than current date.");
            RuleFor (reg => reg.TypeOfStudy)
                .MaximumLength (50)
                .MinimumLength (3);
            RuleFor (reg => reg.Email)
                .EmailAddress ()
                .MinimumLength (5);
        }
    }
}