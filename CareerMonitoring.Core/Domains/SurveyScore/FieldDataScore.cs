using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Core.Domains.SurveyScore {
    public class FieldDataScore {

        public int Id { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public string MinLabel { get; private set; }
        public string MaxLabel { get; private set; }
        public string Input { get; private set; }
        public int InputScore { get; private set; }
        public int QuestionId { get; private set; }
        public QuestionScore Question { get; private set; }
        public ICollection<ChoiceOptionScore> ChoiceOptions { get; private set; } = new List<ChoiceOptionScore> ();
        public ICollection<RowScore> Rows { get; private set; } = new List<RowScore> ();

        private FieldDataScore () { }

        public FieldDataScore (FieldData fieldData) {
            MinValue = fieldData.MinValue;
            MaxValue = fieldData.MaxValue;
            MinLabel = fieldData.MinLabel;
            MaxLabel = fieldData.MaxLabel;
            Input = fieldData.Input;

        }

        public void AddChoiceOption (ChoiceOption choiceOption) {
            ChoiceOptions.Add (new ChoiceOptionScore (choiceOption));
        }
        public void AddRow (Row row) {
            Rows.Add (new RowScore (row));
        }

        public void IncrementInputValue () {
            InputScore++;
        }
    }
}