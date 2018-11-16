namespace CareerMonitoring.Infrastructure.Extension.JWT.Interfaces {
    public interface IJWTSettings {
        string Key { get; set; }
        int ExpiryDays { get; set; }
    }
}