using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveysAnswers {
    public class FieldDataAnswer {
        public int Id { get; private set; }
        public string MinLabel { get; private set; }
        public string MaxLabel { get; private set; }
        public string Input { get; private set; }
        public int QuestionAnswerId { get; private set; }
        public QuestionAnswer QuestionAnswer { get; private set; }
        public ICollection<ChoiceOptionAnswer> ChoiceOptionAnswers { get; private set; } = new List<ChoiceOptionAnswer>();
        public ICollection<RowAnswer> RowsAnswers { get; private set; } = new List<RowAnswer>();

        public FieldDataAnswer () { }

        public void AddChoiceOptionAnswer (ChoiceOptionAnswer choiceOptionAnswer) {
            ChoiceOptionAnswers.Add(choiceOptionAnswer);
        }

        public FieldDataAnswer (string input) {
            Input = input;
        }

        public FieldDataAnswer (string minLabel, string maxLabel) {
            MinLabel = minLabel;
            MaxLabel = maxLabel;
        }

        public void AddRow (RowAnswer rowAnswer) {
            RowsAnswers.Add(rowAnswer);
        }
    }
}