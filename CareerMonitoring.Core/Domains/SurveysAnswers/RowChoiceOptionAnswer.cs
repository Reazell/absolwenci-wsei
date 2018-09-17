namespace CareerMonitoring.Core.Domains.SurveysAnswers
{
    public class RowChoiceOptionAnswer
    {
        public int Id { get; private set; }
        public int OptionPosition { get; private set; }
        public bool Value { get; private set; }
        public string ViewValue { get; private set; }
        public int RowAnswerId { get; private set; }
        public RowAnswer RowAnswer { get; private set; }

        private RowChoiceOptionAnswer () { }

        public RowChoiceOptionAnswer (int optionPosition, bool value, string viewValue) {
            OptionPosition = optionPosition;
            Value = value;
            ViewValue = viewValue;
        }
    }
}