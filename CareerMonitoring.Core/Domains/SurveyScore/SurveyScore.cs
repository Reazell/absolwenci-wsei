using System;
using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Core.Domains.SurveyScore {
    public class SurveyScore {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Answered { get; private set; }
        public ICollection<QuestionScore> Questions { get; private set; } = new List<QuestionScore> ();

        public SurveyScore () { }
    }
}