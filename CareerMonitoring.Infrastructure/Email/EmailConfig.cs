using CareerMonitoring.Infrastructure.Email.Interfaces;

namespace CareerMonitoring.Infrastructure.Email
{
    public class EmailConfig : IEmailConfig
    {
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587;
        public string SmtpUsername { get; set; } = "careermonitoringtest@gmail.com";
        public string SmtpPassword { get; set; } = "careermonitoring2018";
        public string Name { get; set; } = "CareerMonitoring";
    }
}