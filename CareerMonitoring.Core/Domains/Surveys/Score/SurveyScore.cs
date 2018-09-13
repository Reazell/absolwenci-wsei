using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys.Score {
    public class SurveyScore {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime SurveyCreatedAt { get; private set; }
        public DateTime ReportCreatedAt { get; private set; }
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }
        public ICollection<LinearScaleScore> LinearScaleScores { get; private set; }
        public ICollection<MultipleChoiceScore> MultipleChoiceScores { get; private set; }
        public ICollection<MultipleGridScore> MultipleGridScores { get; private set; }
        public ICollection<SingleChoiceScore> SingleChoiceScores { get; private set; }
        public ICollection<SingleGridScore> SingleGridScores { get; private set; }

        protected SurveyScore () { }

        public SurveyScore (Survey survey) {
            Survey = survey;
            Title = survey.Title;
            SurveyCreatedAt = survey.CreatedAt;
            ReportCreatedAt = DateTime.UtcNow;

        }

        public void AddLinearScaleScore (LinearScaleScore linearScaleScore) {
            LinearScaleScores.Add (linearScaleScore);
        }
        public void AddMultipleChoiceScore (MultipleChoiceScore multipleChoiceScore) {
            MultipleChoiceScores.Add (multipleChoiceScore);
        }
        public void AddMultipleGridScore (MultipleGridScore multipleGridScore) {
            MultipleGridScores.Add (multipleGridScore);
        }
        public void AddSingleChoiceScore (ICollection<SingleChoiceScore> singleChoiceScores) {
            SingleChoiceScores = singleChoiceScores;
        }
        public void AddSingleGridScore (SingleGridScore singleGridScore) {
            SingleGridScores.Add (singleGridScore);
        }
    }
}