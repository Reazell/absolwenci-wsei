using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Core.Domains {
    public class SingleGrid {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public ICollection<string> Rows { get; private set; }
        public ICollection<string> Cols { get; private set; }
        public ICollection<Answer> Answers { get; private set; }
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }
        public SingleGrid (string title) {
            Title = title;
        }

        public void AddRow (string row) {
            Rows.Add (row);
        }
        public void AddCol (string col) {
            Cols.Add (col);
        }
        public void AddAnswer (Answer answer) {
            Answers.Add (answer);
        }
    }
}