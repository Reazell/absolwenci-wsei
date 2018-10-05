using System;

namespace CareerMonitoring.Core.Domains.ImportFile {
    public class ImportData {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Course { get; private set; }
        public DateTime DateOfCompletion { get; private set; }
        public string TypeOfStudy { get; private set; }
        public string Email { get; private set; }

        public ImportData () { }

        public ImportData (string name, string surname, string course,
            DateTime dateOfCompletion, string typeOfStudy, string email) {
            SetName (name);
            SetSurname (surname);
            SetCourse (course);
            SetDateOfCompletion (dateOfCompletion);
            SetTypeOfStudy (typeOfStudy);
            SetEmail (email);
        }

        public void SetName (string name) {
            Name = name;
        }
        public void SetSurname (string surname) {
            Surname = surname;
        }
        public void SetCourse (string course) {
            Course = course;
        }
        public void SetDateOfCompletion (DateTime dateOfCompletion) {
            DateOfCompletion = dateOfCompletion;
        }
        public void SetTypeOfStudy (string typeOfStudy) {
            TypeOfStudy = typeOfStudy;
        }
        public void SetEmail (string email) {
            Email = email;
        }
    }
}