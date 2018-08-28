namespace CareerMonitoring.Core.Domains {
    public class Skill {
        public string Name { get; private set; }

        protected Skill () { }

        public Skill (string name) {
            Name = name;
        }
    }
}