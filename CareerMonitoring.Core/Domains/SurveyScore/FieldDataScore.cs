using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveyScore {
    public class FieldDataScore {

        public int Id { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public string MinLabel { get; private set; }
        public string MaxLabel { get; private set; }
        public int Input { get; private set; }
        public int QuestionId { get; private set; }
        public QuestionScore Question { get; private set; }
        public ICollection<ChoiceOptionScore> ChoiceOptions { get; private set; } = new List<ChoiceOptionScore> ();
        public ICollection<RowScore> Rows { get; private set; } = new List<RowScore> ();

        private FieldDataScore () { }

        public void IncrementInputValue () {
            Input++;
        }
    }
}