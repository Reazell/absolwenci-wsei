namespace CareerMonitoring.Core.Domains.SurveyReport
{
    public class ChoiceOptionReport
    {
        public int Id { get; private set; }
        public int OptionPosition { get; private set; }
        public int OptionCounter { get; private set; }
        public string ViewValue { get; private set; }
        public int QuestionReportId { get; private set; }
        public QuestionReport QuestionReport { get; private set; }
    }
}