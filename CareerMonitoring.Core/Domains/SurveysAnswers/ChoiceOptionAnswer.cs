namespace CareerMonitoring.Core.Domains.SurveysAnswers {
    public class ChoiceOptionAnswer {
        public int Id { get; private set; }
        public int OptionPosition { get; private set; }
        public bool Value { get; private set; }
        public string ViewValue { get; private set; }
        public int FieldDataAnswerId { get; private set; }
        public FieldDataAnswer FieldDataAsnwer { get; private set; }
        public int RowAnswerId { get; private set; }
        public RowAnswer RowAnswer { get; private set; }
    }
}