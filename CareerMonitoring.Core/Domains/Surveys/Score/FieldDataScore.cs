using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys.Score {
    public class FieldDataScore {

        public int Id { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public string MinLabel { get; private set; }
        public string MaxLabel { get; private set; }
        public int Input { get; private set; }
        public int QuestionId { get; private set; }
        public QuestionScore Question { get; private set; }
        public ICollection<ChoiceScore> ChoiceOptions { get; private set; }
        public ICollection<Row> Rows { get; private set; }

        private FieldDataScore () { }

        // public FieldDataScore (ICollection<ChoiceOption> choiceOptions) {
        //     ChoiceOptions = choiceOptions;
        // }

        public FieldDataScore (int minValue, int maxValue, string minLabel, string maxLabel) {
            MinValue = minValue;
            MaxValue = maxValue;
            MinLabel = minLabel;
            MaxLabel = maxLabel;
        }

        public void IncrementInputValue () {
            Input++;
        }

        // public FieldDataScore (ICollection<ChoiceOption> choiceOptions, ICollection<Row> rows) {
        //     ChoiceOptions = choiceOptions;
        //     Rows = rows;
        // }
    }
}