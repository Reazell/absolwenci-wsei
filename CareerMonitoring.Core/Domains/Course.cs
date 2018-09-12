namespace CareerMonitoring.Core.Domains {
    public class Course {
        public int Id { get; private set; }
        public string Name { get; private set; }

        protected Course () { }

        public Course (string name) {
            Name = name;
        }
    }
}