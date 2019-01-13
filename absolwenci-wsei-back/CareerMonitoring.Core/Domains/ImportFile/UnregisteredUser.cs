using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Core.Domains.ImportFile {
    public class UnregisteredUser {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public ICollection<UserGroup> Groups { get; private set; } = new List<UserGroup>();

        public UnregisteredUser () {
            Role = "unregisteredUser";
        }

        public UnregisteredUser (string name, string surname,  string email) {
            SetName (name);
            SetSurname (surname);
            SetEmail (email);
            Role = "unregisteredUser";
        }

        public void SetName (string name) {
            Name = name;
        }

        public void SetSurname (string surname) {
            Surname = surname;
        }


        public void SetEmail (string email) {
            Email = email;
        }

        public void Update (string name, string surname, string email) {
            SetName (name);
            SetSurname (surname);
            SetEmail (email);
        }
    }
}