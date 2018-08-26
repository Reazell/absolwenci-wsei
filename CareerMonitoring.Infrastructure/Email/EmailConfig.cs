using CareerMonitoring.Infrastructure.Email.Interfaces;

namespace CareerMonitoring.Infrastructure.Email
{
    public class EmailConfig : IEmailConfig
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string Name { get; set; }
    }
}