using System;
using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Student : Account {
        public string IndexNumber { get; private set; }

        protected Student () { }

        public Student (string name, string surname, string email, string indexNumber, string phoneNumber, string password) : base (name, surname, email, phoneNumber, password) {
            Role = "student";
            IndexNumber = indexNumber;
        }

        public void Update (string name, string surname, string email, string phoneNumber) {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}