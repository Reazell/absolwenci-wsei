using System;

namespace CareerMonitoring.Infrastructure.DTO.ImportFile {
    public class UnregisteredUserDto {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
    }
}