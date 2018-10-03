namespace CareerMonitoring.Core.Domains.ImportFile {
    public class ImportData {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public ImportData () { }

        public ImportData (string name, string surname, string email) {
            SetName (name);
            SetSurname (surname);
            SetEmail (email);
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
    }
}