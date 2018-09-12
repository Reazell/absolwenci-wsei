using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Core.Domains.Surveys.Answers
{
    public class MultipleChoiceAnswer : Answer
    {
        public string MarkedAnswers
        {
            get { return string.Join (",", _markedAnswers);}
            private set { _markedAnswers = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _markedAnswers { get; private set; }
        public MultipleChoice MultipleChoice { get; private set; }
        private MultipleChoiceAnswer () {}

        public MultipleChoiceAnswer (ICollection<string> markedAnswers)
        {
            _markedAnswers = markedAnswers;
            QuestionType = "multipleChoice";
        }
    }
}