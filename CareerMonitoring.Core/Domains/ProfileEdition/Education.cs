using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Education {
        public int Id { get; private set; }
        public string Course { get; private set; }
        public int Year { get; private set; }
        public string Specialization { get; private set; }
        public string NameOfUniversity { get; private set; }
        public bool Graduated { get; private set; }
        public int AccountId { get; private set; }
        public Account Account { get; private set; }

        protected Education () { }

        public Education (string course, int year, string specialization, string nameOfUniveristy, bool graduated) {
            Course = course;
            Year = year;
            Specialization = specialization;
            Graduated = graduated;
            NameOfUniversity = nameOfUniveristy;
        }
    }
}