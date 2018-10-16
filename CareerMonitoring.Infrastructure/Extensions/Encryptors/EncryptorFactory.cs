using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CareerMonitoring.Infrastructure.Extensions.Encryptors.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace CareerMonitoring.Infrastructure.Extensions.Encryptors
{
    public class EncryptorFactory : IEncryptorFactory
    {
        public string EncryptStringValue(string text)
        {
            
            return text;
        }

        public string DecryptStringValue(string text)
        {
            return text;
        }
    }
}