namespace CareerMonitoring.Infrastructure.Commands.User {
    public class RegisterUser {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public int IndexNumber { get; private set; }
        public string Password { get; private set; }
    }
}