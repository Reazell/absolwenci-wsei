using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveyReport
{
    public class QuestionReport
    {
        public int Id { get; private set; }
        public int QuestionPosition { get; private set; }
        public string Content { get; private set; }
        public string Select { get; private set; }
        public int AnswersNumber { get; private set; }
        public string MinLabel { get; private set; }
        public string MaxLabel { get; private set; }
        public int SurveyReportId { get; private set; }
        public SurveyReport SurveyReport { get; private set; }
        public ICollection<ChoiceOptionReport> ChoiceOptionReports { get; private set; }
    }
}