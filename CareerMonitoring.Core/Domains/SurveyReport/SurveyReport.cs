using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveyReport
{
    public class SurveyReport
    {
        public int Id { get; private set; }
        public string SurveyTitle { get; private set; }
        public int AnswersNumber { get; private set; }
        public int SurveyId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<QuestionReport> QuestionsReports { get; private set; } = new List<QuestionReport>();
    }
}