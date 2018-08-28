using System;
using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Student : Account {
        public int IndexNumber { get; private set; }
        public string ProfileLink { get; private set; }
        public ICollection<Education> Educations { get; private set; }
        public ICollection<Experience> Experiences { get; private set; }
        public ICollection<Certificate> Certificates { get; private set; }
        public ICollection<Skill> Skills { get; private set; }
        public ICollection<Course> Courses { get; private set; }
        public ICollection<Language> Languages { get; private set; }

        protected Student () { }

        public Student (string name, string surname, string email, int indexNumber, string phoneNumber, string password) : base (name, surname, email, phoneNumber, password) {
            Role = "student";
            IndexNumber = indexNumber;
        }

        public void Update (string name, string surname, string email) {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public void AddProfileLink (string profileLink) {
            ProfileLink = profileLink;
        }

        public void AddEducation (Education education) {
            Educations.Add (education);
        }
        public void AddExperience (Experience experience) {
            Experiences.Add (experience);
        }
        public void AddCertificate (Certificate certificate) {
            Certificates.Add (certificate);
        }
        public void AddSkill (Skill skill) {
            Skills.Add (skill);
        }
        public void AddCourse (Course course) {
            Courses.Add (course);
        }
        public void AddLanguage (Language language) {
            Languages.Add (language);
        }
    }
}