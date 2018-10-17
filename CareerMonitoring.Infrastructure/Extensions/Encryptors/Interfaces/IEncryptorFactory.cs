using System.Collections.Specialized;

namespace CareerMonitoring.Infrastructure.Extensions.Encryptors.Interfaces
{
    public interface IEncryptorFactory
    {
        string EncryptStringValue(string input);
        string DecryptStringValue(string input);
    }
}