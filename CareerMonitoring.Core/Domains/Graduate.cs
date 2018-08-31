using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Graduate : Account {
        public string ProfileLink { get; private set; }
        public ICollection<Education> Educations { get; private set; }
        public ICollection<Experience> Experiences { get; private set; }
        public ICollection<Certificate> Certificates { get; private set; }
        public ICollection<Skill> Skills { get; private set; }
        public ICollection<Course> Courses { get; private set; }
        public ICollection<Language> Languages { get; private set; }

        protected Graduate () { }

        public Graduate (string name, string surname, string email, string phoneNumber, string password) : base (name, surname, email, phoneNumber, password) {
            Role = "graduate";
        }

        public void Update (string name, string surname, string email, string phoneNumber) {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
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