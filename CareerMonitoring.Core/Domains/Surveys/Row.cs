namespace CareerMonitoring.Core.Domains.Surveys {
    public class Row {
        public int Id { get; private set; }
        public int RowPosition { get; private set; }
        public string Input { get; private set; }
        public int FieldDataId { get; private set; }
        public FieldData FieldData { get; private set; }

        private Row () { }
    }
}