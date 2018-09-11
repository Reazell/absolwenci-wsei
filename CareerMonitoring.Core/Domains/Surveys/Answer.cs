namespace CareerMonitoring.Core.Domains.Surveys {
    public class Answer {
        public int Id { get; private set; }
        public string RowTitle { get; private set; }
        public string ColTitle { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set;}
        public LinearScale LinearScale { get; private set; }
        public MultipleChoice MultipleChoice { get; private set; }
        public MultipleGrid MultipleGrid { get; private set; }
        public OpenQuestion OpenQuestion { get; private set; }
        public SingleChoice SingleChoice { get; private set; }
        public SingleGrid SingleGrid { get; private set; }

        public Answer (string rowTitle, string colTitle) {
            RowTitle = rowTitle;
            ColTitle = colTitle;
        }
    }
}