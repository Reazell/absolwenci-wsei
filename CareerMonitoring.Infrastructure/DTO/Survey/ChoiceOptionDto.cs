namespace CareerMonitoring.Infrastructure.DTO.Survey {
    public class ChoiceOptionDto {
        public int OptionPosition { get; set; }
        public bool Value { get; set; }
        public string ViewValue { get; set; }

        public int NumericalValue { get; set; }

        public void AddNumericalValue () {
            NumericalValue++;
        }
    }
}