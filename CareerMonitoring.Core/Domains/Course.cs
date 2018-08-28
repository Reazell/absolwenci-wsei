namespace CareerMonitoring.Core.Domains {
    public class Course {
        public string Name { get; private set; }

        protected Course () { }
        
        public Course (string name) {
            Name = name;
        }
    }
}