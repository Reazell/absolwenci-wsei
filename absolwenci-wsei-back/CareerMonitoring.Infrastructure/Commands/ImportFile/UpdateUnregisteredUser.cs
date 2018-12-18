using System;

namespace CareerMonitoring.Infrastructure.Commands.ImportFile {
    public class UpdateUnregisteredUser {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}