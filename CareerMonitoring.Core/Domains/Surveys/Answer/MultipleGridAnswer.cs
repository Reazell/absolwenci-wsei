using System.Linq;

namespace CareerMonitoring.Core.Domains.Surveys.Answer
{
    public class MultipleGridAnswer
    {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set; }
        public string RowTitle { get; private set; }
        public string ColTitle { get; private set; }

        public MultipleGrid MultipleGrid { get; private set; }

        private MultipleGridAnswer () {}

        public MultipleGridAnswer (string rowTitle, string colTitle) {
            RowTitle = rowTitle;
            ColTitle = colTitle;
            QuestionType = "multipleGrid";
        }
    }
}