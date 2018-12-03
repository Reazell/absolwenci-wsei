using System;

namespace CareerMonitoring.Infrastructure.Commands.ProfileEdition
{
    public class UpdateCertificate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfReceived { get; set; }
    }
}