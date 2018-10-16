using CareerMonitoring.Infrastructure.Extension.JWT.Interfaces;

namespace CareerMonitoring.Infrastructure.Extensions.JWT
{
    public class JWTSettings : IJWTSettings {
        public string Key { get; set; }
        public int ExpiryDays { get; set; }
    }
}