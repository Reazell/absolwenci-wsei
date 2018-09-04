namespace CareerMonitoring.Core.Domains {
    public class Question {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public enum Type { SingleChoice, MultipleChoice, List, Scale }

    }
}