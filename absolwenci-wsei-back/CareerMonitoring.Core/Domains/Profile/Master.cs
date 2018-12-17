using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains{
    public class Master:Account{
        
        public Master(){}
        
        public Master (string name, string surname, string email, string phoneNumber, string password) : base (name, surname, email, phoneNumber, password) {
            Role = "master";
        }

        public void Update (string name, string surname, string email, string phoneNumber) {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}