using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.Surveys.Answer
{
    public class SingleGridAnswer
    {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set; }
        public string RowTitle { get; private set; }
        public string ColTitle { get; private set; }

        public SingleGrid SingleGrid { get; private set; }

        private SingleGridAnswer () {}

        public SingleGridAnswer (string rowTitle, string colTitle) {
            RowTitle = rowTitle;
            ColTitle = colTitle;
            QuestionType = "singleGrid";
        }
    }
}