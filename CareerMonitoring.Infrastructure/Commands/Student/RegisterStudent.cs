namespace CareerMonitoring.Infrastructure.Commands.User {
    public class RegisterStudent {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int IndexNumber { get; set; }
        public string Password { get; set; }
    }
}