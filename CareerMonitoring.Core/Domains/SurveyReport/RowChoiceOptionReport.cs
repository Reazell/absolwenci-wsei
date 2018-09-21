namespace CareerMonitoring.Core.Domains.SurveyReport
{
    public class RowChoiceOptionReport
    {
        public int Id { get; private set; }
        public int OptionPosition { get; private set; }
        public string ViewValue { get; private set; }
        public int RowReportId { get; private set; }
        public RowReport RowReport { get; private set; }

        private RowChoiceOptionReport () { }

        public RowChoiceOptionReport (int optionPosition, string viewValue) {
            OptionPosition = optionPosition;
            ViewValue = viewValue;
        }
    }
}