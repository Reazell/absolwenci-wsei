using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class CareerOffice : Account {
        public CareerOffice () { }

        public CareerOffice (string name, string surname, string email, string phoneNumber, string password) : base (name, surname, email, phoneNumber, password) {
            Role = "careerOffice";
        }
    }
}