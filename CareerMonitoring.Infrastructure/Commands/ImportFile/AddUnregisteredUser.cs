using System;

namespace CareerMonitoring.Infrastructure.Commands.ImportFile {
    public class AddUnregisteredUser {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Course { get; set; }
        public string DateOfCompletion { get; set; }
        public string TypeOfStudy { get; set; }
        public string Email { get; set; }
    }
}