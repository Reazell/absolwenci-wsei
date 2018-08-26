namespace CareerMonitoring.Infrastructure.Email.Interfaces
{
    public interface IEmailConfig
    {
        string SmtpServer { get; set; }
        int SmtpPort { get; set; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }
        string Name { get; set; }
    }
}