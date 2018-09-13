using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CareerMonitoring.Core.Domains.Surveys.Answers;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class MultipleGrid {
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
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }
        public ICollection<MultipleGridAnswer> MultipleGridAnswers { get; private set; }

        private MultipleGrid () {}

        public MultipleGrid (string content, ICollection<string> rows, ICollection<string> cols) {
            Content = content;
            _rows = rows;
            _cols = cols;
        }
    }
}