using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Infrastructure.Email.Interfaces
{
    public interface IUserEmailSender
    {
        Task SendActivationEmailAsync(User user, Guid activationKey);
    }
}