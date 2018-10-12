using CareerMonitoring.Infrastructure.Extension.JWT.Interfaces;

namespace CareerMonitoring.Infrastructure.Extension.JWT {
    public class JWTSettings : IJWTSettings {
        public string Key { get; set; }
        public int ExpiryDays { get; set; }
    }

}