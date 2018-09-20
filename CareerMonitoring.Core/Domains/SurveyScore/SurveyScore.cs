using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveyScore {
    public class SurveyScore {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<SurveySingleScore> SurveySingleScores { get; private set; } = new List<SurveySingleScore>();

        private SurveyScore () { }
        public SurveyScore (string title)
        {
            Title = title;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddSingleSurveyScore (SurveySingleScore surveySingleScore)
        {
            SurveySingleScores.Add(surveySingleScore);
        }
    }
}