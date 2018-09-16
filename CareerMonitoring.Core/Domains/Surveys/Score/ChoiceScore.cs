namespace CareerMonitoring.Core.Domains.Surveys.Score {
    public class ChoiceScore {
        public int Id { get; private set; }
        public int OptionPosition { get; private set; }
        public string ViewValue { get; private set; }
        public double PercentageValue { get; private set; }
        public double NumericalValue { get; private set; }
        public int FieldDataId { get; private set; }
        public FieldDataScore FieldData { get; private set; }

        public ChoiceScore () { }
        public ChoiceScore (ChoiceOption choiceOption) {
            OptionPosition = choiceOption.OptionPosition;
            ViewValue = choiceOption.ViewValue;
        }

        public ChoiceScore (string viewValue, double percentageValue, double numericalValue) {
            ViewValue = viewValue;
            PercentageValue = percentageValue;
            NumericalValue = numericalValue;
        }

        public void AddNumericalValue () {
            NumericalValue++;
        }

        public void AddViewValue (string viewValue) {
            ViewValue = viewValue;
        }
    }
}