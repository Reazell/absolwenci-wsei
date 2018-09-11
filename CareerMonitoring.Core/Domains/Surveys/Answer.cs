using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class Answer {
        public int Id { get; private set; }
        public string RowTitle { get; private set; }
        public string ColTitle { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set;}
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

        public Answer (string rowTitle, string colTitle) {
            RowTitle = rowTitle;
            ColTitle = colTitle;
        }
    }
}