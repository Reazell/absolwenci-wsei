using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveyReport
{
    public class RowReport
    {
        public int Id { get; private set; }
        public int RowPostion { get; private set; }
        public string Input { get; private set; }
        public int QuestionReportId { get; private set; }
        public QuestionReport QuestionReport { get; private set; }
        public ICollection<RowChoiceOptionReport> RowChoiceOptionReports { get; private set; }
    }
}