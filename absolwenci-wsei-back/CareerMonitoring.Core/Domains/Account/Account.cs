using System;
using System.Collections.Generic;
using CareerMonitoring.Core.Domains;

namespace CareerMonitoring.Core.Domains.Abstract {
    public abstract class Account {
        public int Id { get; private set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public byte[] PasswordSalt { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public bool Deleted { get; protected set; }
        public bool Activated { get; protected set; }
        public AccountActivation AccountActivation { get; protected set; }
        public AccountRestoringPassword AccountRestoringPassword { get; protected set; }
        public ProfileLink ProfileLink { get; protected set; }
        public ICollection<Education> Educations { get; protected set; }
        public ICollection<Experience> Experiences { get; protected set; }
        public ICollection<Certificate> Certificates { get; protected set; }
        public ICollection<Skill> Skills { get; protected set; }
        public ICollection<Course> Courses { get; protected set; }
        public ICollection<Language> Languages { get; protected set; }

        protected Account () { }

        public Account (string name, string surname, string email, string phoneNumber, string password) {
            SetName (name);
            SetSurname (surname);
            SetEmail (email);
            SetPhoneNumber (phoneNumber);
            CreatePasswordHash (password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Deleted = false;
            Activated = false;
        }

        public Account (string email) {
            Email = email;
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
        public void SetPhoneNumber (string phoneNumber) {
            PhoneNumber = phoneNumber;
        }

        public void Activate (AccountActivation accountActivation) {
            if (!accountActivation.Active) {
                Activated = true;
                UpdatedAt = DateTime.UtcNow;
                accountActivation.Activate ();
            }
        }

        public void Delete () {
            if (Deleted == false) {
                Deleted = true;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void UpdatePassword (string newPassword) {
            CreatePasswordHash (newPassword);
            UpdatedAt = DateTime.UtcNow;
        }

        private void CreatePasswordHash (string password) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 ()) {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
            }
        }

        public void AddAccountActivation (AccountActivation accountActivation) {
            AccountActivation = accountActivation;
        }

        public void ChangeAccountRestoringPassword (Guid token) {
            if (AccountRestoringPassword != null)
                AccountRestoringPassword.ResetState (token);
        }

        public void AddAccountRestoringPassword (AccountRestoringPassword accountRestoringPassword) {
            if (accountRestoringPassword != null)
                AccountRestoringPassword = accountRestoringPassword;
        }

        public void AddProfileLink (ProfileLink profileLink) {
            if (Role == "student" || Role == "graduate")
                ProfileLink = profileLink;
            else
                throw new Exception ("Inccorect role.");
        }

        public void RemoveProfileLink ()
        {
            if (Role == "student" || Role == "graduate")
                ProfileLink = null;
            else
                throw new Exception("Inccorect role.");
        }

        public void AddEducation (Education education) {
            if (Role == "student" || Role == "graduate")
                Educations.Add (education);
            else
                throw new Exception ("Inccorect role.");
        }

        public void UpdateEducation (int id, Education education) {
            if (Role == "student" || Role == "graduate")
                foreach (var c in Educations)
                {
                    if (c.Id == id)
                    {
                        RemoveEducation(c);
                        AddEducation(education);
                        return;
                    }
                }
            else
                throw new Exception ("Inccorect role.");
        }

        public void RemoveEducation (Education education) {
            if (Role == "student" || Role == "graduate")
                Educations.Remove(education);
            else
                throw new Exception ("Inccorect role.");
        }

        public void AddExperience (Experience experience) {
            if (Role == "student" || Role == "graduate")
                Experiences.Add (experience);
            else
                throw new Exception ("Inccorect role.");
        }

        public void UpdateExperience (int id, Experience experience) {
            if (Role == "student" || Role == "graduate")
                foreach (var c in Experiences)
                {
                    if (c.Id == id)
                    {
                        RemoveExperience(c);
                        AddExperience(experience);
                        return;
                    }
                }
            else
                throw new Exception ("Inccorect role.");
        }

        public void RemoveExperience (Experience experience) {
            if (Role == "student" || Role == "graduate")
                Experiences.Remove(experience);
            else
                throw new Exception ("Inccorect role.");
        }

        public void AddCertificate (Certificate certificate) {
            if (Role == "student" || Role == "graduate")
                Certificates.Add (certificate);
            else
                throw new Exception ("Inccorect role.");
        }

        public void UpdateCertificate (int id, Certificate certificate) {
            if (Role == "student" || Role == "graduate")
                foreach (var c in Certificates)
                {
                    if (c.Id == id)
                    {
                        RemoveCertificate(c);
                        AddCertificate(certificate);
                        return;
                    }
                }
            else
                throw new Exception ("Inccorect role.");
        }

        public void RemoveCertificate (Certificate certificate) {
            if (Role == "student" || Role == "graduate")
                Certificates.Remove(certificate);
            else
                throw new Exception ("Inccorect role.");
        }

        public void AddSkill (Skill skill) {
            if (Role == "student" || Role == "graduate")
                Skills.Add (skill);
            else
                throw new Exception ("Inccorect role.");
        }

        public void RemoveSkill (Skill skill) {
            if (Role == "student" || Role == "graduate")
                Skills.Remove(skill);
            else
                throw new Exception ("Inccorect role.");
        }

        public void AddCourse (Course course) {
            if (Role == "student" || Role == "graduate")
                Courses.Add (course);
            else
                throw new Exception ("Inccorect role.");
        }

        public void UpdateCourse (int id, Course course) {
            if (Role == "student" || Role == "graduate")
                foreach (var c in Courses)
                {
                    if (c.Id == id)
                    {
                        RemoveCourse(c);
                        AddCourse(course);
                        return;
                    }
                }
            else
                throw new Exception ("Inccorect role.");
        }

        public void RemoveCourse (Course course) {
            if (Role == "student" || Role == "graduate")
                Courses.Remove(course);
            else
                throw new Exception ("Inccorect role.");
        }

        public void AddLanguage (Language language) {
            if (Role == "student" || Role == "graduate")
                Languages.Add (language);
            else
                throw new Exception ("Inccorect role.");
        }

        public void UpdateLanguage (int id, Language language) {
            if (Role == "student" || Role == "graduate")
                foreach (var c in Languages)
                {
                    if (c.Id == id)
                    {
                        RemoveLanguage(c);
                        AddLanguage(language);
                        return;
                    }
                }
            else
                throw new Exception ("Inccorect role.");
        }

        public void RemoveLanguage (Language language) {
            if (Role == "student" || Role == "graduate")
                Languages.Remove(language);
            else
                throw new Exception ("Inccorect role.");
        }
    }
}