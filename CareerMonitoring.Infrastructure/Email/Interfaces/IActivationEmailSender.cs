using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Email.Interfaces
{
    public interface IActivationEmailSender
    {
        Task SendActivationEmailAsync(User user, Guid activationKey);
    }
}