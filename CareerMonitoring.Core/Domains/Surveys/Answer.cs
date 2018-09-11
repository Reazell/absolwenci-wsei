using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class Answer {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set;}
        public string OpenQuestionAnswer { get; private set; }
        public string MarkedAnswers
        {
            get { return string.Join (",", _markedAnswers);}
            private set { _markedAnswers = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _markedAnswers { get; private set; }
        public string MarkedAnswer { get; private set; }
        public string Rows
        {
            get { return string.Join (",", _rows); }
            private set { _rows = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _rows { get; private set; }
        public string MarkedCols
        {
            get { return string.Join (",", _cols); }
            private set { _cols = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _cols { get; private set; }
        public string MarkedCol
        {
            get { return string.Join (",", _col); }
            private set { _col = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _col { get; private set; }
        public int MarkedValue { get; private set; }
        public LinearScale LinearScale { get; private set; }
        public MultipleChoice MultipleChoice { get; private set; }
        public MultipleGrid MultipleGrid { get; private set; }
        public OpenQuestion OpenQuestion { get; private set; }
        public SingleChoice SingleChoice { get; private set; }
        public SingleGrid SingleGrid { get; private set; }

        private Answer () {}

        public Answer (string openQuestionAnswer)
        {
            QuestionType = "OpenQuestion";
            OpenQuestionAnswer = openQuestionAnswer;
        }

        public Answer (ICollection<string> markedAnswers)
        {
            QuestionType = "OpenQuestion";
            _markedAnswers = markedAnswers;
        }

        public void AnswerLinearScale ()
        {

        }

        public void AnswerMultipleChoice ()
        {

        }

        public void AnswerMultipleGrid ()
        {

        }

        public void AnswerOpenQuestion ()
        {

        }

        public void AnswerSingleChoice ()
        {

        }

        public void AnswerSingleGrid ()
        {

        }
    }
}