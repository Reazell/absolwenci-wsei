namespace CareerMonitoring.Core.Domains.SurveysAnswers {
    public class ChoiceOptionAnswer {
        public int Id { get; private set; }
        public int OptionPosition { get; private set; }
        public bool Value { get; private set; }
        public string ViewValue { get; private set; }
        public int FieldDataAnswerId { get; private set; }
        public FieldDataAnswer FieldDataAnswer { get; private set; }

        private ChoiceOptionAnswer () { }

        public ChoiceOptionAnswer (int optionPosition, bool value, string viewValue) {
            OptionPosition = optionPosition;
            Value = value;
            ViewValue = viewValue;
        }
    }
}