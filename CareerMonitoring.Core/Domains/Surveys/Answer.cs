namespace CareerMonitoring.Core.Domains.Surveys {
    public class Answer {
        public int Id { get; private set; }
        public string RowTitle { get; private set; }
        public string ColTitle { get; private set; }

        public Answer (string rowTitle, string colTitle) {
            RowTitle = rowTitle;
            ColTitle = colTitle;
        }
    }
}