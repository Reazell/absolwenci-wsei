using System;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Student : Account {
        public int IndexNumber { get; private set; }
        protected Student () { }

        public Student (string name, string surname, string email, int indexNumber, string password) : base (name, surname, email, password) {
            Role = "student";
            IndexNumber = indexNumber;
        }
    }
}