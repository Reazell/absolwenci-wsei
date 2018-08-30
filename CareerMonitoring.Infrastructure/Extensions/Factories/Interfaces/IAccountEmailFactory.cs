using System;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Infrastructure.Extensions.Factories.Interfaces {
    public interface IAccountEmailFactory {
        Task SendActivationEmailAsync (Account account, Guid activationKey);
        Task SendRecoveringPasswordEmailAsync (Account account, Guid token);
        Task SendEmailToAllAsync (string subejct, string body);
    }
}