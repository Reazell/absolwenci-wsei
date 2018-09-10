using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Course {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int AccountId { get; private set; }
        public Account Account { get; private set; }

        protected Course () { }
        
        public Course (string name) {
            Name = name;
        }
    }
}