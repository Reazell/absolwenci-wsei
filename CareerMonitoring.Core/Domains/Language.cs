namespace CareerMonitoring.Core.Domains {
    public class Language {
        public string Name { get; private set; }
        public string Proficiency { get; private set; }

        protected Language () { }

        public Language (string name, string proficiency) {
            Name = name;
            Proficiency = proficiency;
        }
    }
}