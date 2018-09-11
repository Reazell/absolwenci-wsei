using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class SingleGrid {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public string Rows
        {
            get { return string.Join (",", _rows); }
            private set { _rows= value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _rows { get; private set; }
        public string Cols
        {
            get { return string.Join (",", _cols); }
            private set { _cols= value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _cols { get; private set; }
        public ICollection<Answer> Answers { get; private set; }
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }

        private SingleGrid () {}

        public SingleGrid (string content, ICollection<string> rows, ICollection<string> cols) {
            Content = content;
            _rows = rows;
            _cols = cols;
        }

        public void AddRow (string row) {
            _rows.Add(row);
        }
        public void AddCol (string col) {
            _cols.Add (col);
        }
        public void AddAnswer (Answer answer) {
            Answers.Add (answer);
        }
    }
}