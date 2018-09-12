using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.Surveys.Answer
{
    public class MultipleChoiceAnswer
    {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set; }
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