using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CareerMonitoring.Infrastructure.Extensions.Encryptors.Interfaces;

namespace CareerMonitoring.Infrastructure.Extensions.Encryptors
{
    public class EncryptorFactory : IEncryptorFactory
    {
        public string EncryptStringValue(string value)
        {
            return Eramake.eCryptography.Encrypt(value);
        }

        public string DecryptStringValue(string value)
        {
            return Eramake.eCryptography.Decrypt(value);
        }
    }
}