namespace CareerMonitoring.Core.Domains.Surveys {
    public class ChoiceOption {
        public int Id { get; private set; }
        public int OptionPosition { get; private set; }
        public bool Value { get; private set; }
        public string ViewValue { get; private set; }
        public int FieldDataId { get; private set; }
        public FieldData FieldData { get; private set; }

        private ChoiceOption () { }

        public ChoiceOption (int optionPosition, bool value, string viewValue) {
            OptionPosition = optionPosition;
            Value = value;
            ViewValue = viewValue;
        }

        public void Update (int optionPosition, bool value, string viewValue)
        {
            OptionPosition = optionPosition;
            Value = value;
            ViewValue = viewValue;
        }
    }
}