using System;

namespace CareerMonitoring.Core.Domains
{
    public class User {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public int IndexNumber { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Deleted { get; private set; }
        public bool Activated { get; private set; }
        public Guid ActivationKey { get; private set; }

        protected User () { }

        public User (string name, string surname, string email, int indexNumber, string password) {
            Name = name;
            Surname = surname;
            Email = email;
            Role = "user";
            IndexNumber = indexNumber;
            CreatePasswordHash (password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Deleted = false;
            ActivationKey = Guid.NewGuid();
            Activated = false;
        }
        public void Activate (Guid activationKey)
        {
            if(this.ActivationKey == activationKey)
                Activated = true;
        }

        public void Update (string name, string surname) {
            Name = name;
            Surname = surname;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Delete () {
            if (Deleted == false) {
                Deleted = true;
                UpdatedAt = DateTime.UtcNow;
            }
        }

        private void CreatePasswordHash (string password) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 ()) {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
            }
        }

    }
}