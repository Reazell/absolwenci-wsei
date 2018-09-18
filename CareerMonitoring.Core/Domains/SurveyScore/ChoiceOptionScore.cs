using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveyScore;

namespace CareerMonitoring.Core.Domains.SurveyScore {
    public class ChoiceOptionScore {
        public int Id { get; private set; }
        public int OptionPosition { get; private set; }
        public string ViewValue { get; private set; }
        public double PercentageValue { get; private set; }
        public double NumericalValue { get; private set; }
        public int FieldDataId { get; private set; }
        public FieldDataScore FieldData { get; private set; }

        private ChoiceOptionScore () { }

        public ChoiceOptionScore (ChoiceOption choiceOption) {
            OptionPosition = choiceOption.OptionPosition;
            ViewValue = choiceOption.ViewValue;
        }

        public void AddNumericalValue () {
            NumericalValue++;
        }
    }
}