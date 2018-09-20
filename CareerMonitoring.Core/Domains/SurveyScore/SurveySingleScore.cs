using System;
using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Core.Domains.SurveyScore {
    public class SurveySingleScore {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<QuestionScore> Questions { get; private set; } = new List<QuestionScore> ();

        public SurveySingleScore () { }

        public SurveySingleScore (Survey survey) {
            Title = survey.Title;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddQuestion (Question question) {
            Questions.Add (new QuestionScore(question));
        }
    }
}