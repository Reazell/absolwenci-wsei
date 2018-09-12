using System.Linq;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Core.Domains.Surveys.Answers
{
    public class MultipleGridAnswer : Answer
    {
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