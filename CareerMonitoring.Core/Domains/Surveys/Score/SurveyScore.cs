using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys.Score {
    public class SurveyScore {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ReportCreatedAt { get; private set; }
        public ICollection<QuestionScore> Questions { get; private set; }
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }

        public SurveyScore () { }

        public SurveyScore (Survey survey) {
            Title = survey.Title;;
            CreatedAt = survey.CreatedAt;
            ReportCreatedAt = DateTime.UtcNow;
        }
        public void AddQuestion (QuestionScore questionScore) {
            Questions.Add (questionScore);
        }
    }
}