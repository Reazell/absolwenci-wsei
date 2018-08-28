using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Graduate : Account {
        public string ProfileLink { get; private set; }
        public ICollection<Education> Education { get; private set; }
        public ICollection<Experience> Experience { get; private set; }
        public ICollection<Certificate> Certificate { get; private set; }
        public ICollection<Skill> Skill { get; private set; }
        public ICollection<Course> Course { get; private set; }
        public ICollection<Language> Language { get; private set; }

        protected Graduate () { }

        public Graduate (string name, string surname, string email, string password) : base (name, surname, email, password) {
            Role = "graduate";
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
            Education.Add (education);
        }
        public void AddExperience (Experience experience) {
            Experience.Add (experience);
        }
        public void AddCertificate (Certificate certificate) {
            Certificate.Add (certificate);
        }
        public void AddSkill (Skill skill) {
            Skill.Add (skill);
        }
        public void AddCourse (Course course) {
            Course.Add (course);
        }
        public void AddLanguage (Language language) {
            Language.Add (language);
        }
    }
}