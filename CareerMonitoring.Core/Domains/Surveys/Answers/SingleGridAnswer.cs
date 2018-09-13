using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Core.Domains.Surveys.Answers
{
    public class SingleGridAnswer : Answer
    {
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