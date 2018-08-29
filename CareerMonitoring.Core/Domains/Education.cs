namespace CareerMonitoring.Core.Domains {
    public class Education {
        public int Id { get; private set; }
        public string Course { get; private set; }
        public int Year { get; private set; }
        public string Specialization { get; private set; }
        public bool Graduate { get; private set; }

        protected Education () { }

        public Education (string course, int year, string specialization, bool graduate) {
            Course = course;
            Year = year;
            Specialization = specialization;
            Graduate = graduate;
        }
    }
}