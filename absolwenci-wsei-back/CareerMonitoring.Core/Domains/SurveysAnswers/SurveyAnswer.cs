using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveysAnswers {
    public class SurveyAnswer {
        public int Id { get; private set; }
        public string SurveyTitle { get; private set; }
        public string description { get; private set; }
        public int SurveyId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<QuestionAnswer> QuestionsAnswers { get; private set; } = new List<QuestionAnswer>();

        private SurveyAnswer () { }

        public SurveyAnswer (string surveyTitle, string description, int surveyId) {
            SetSurveyTitle(surveyTitle);
            SetSurveyDescription(description);
            SetSurveyId(surveyId);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetSurveyTitle (string surveyTitle) {
            SurveyTitle = surveyTitle;
        }

        public void SetSurveyDescription (string description) {
            this.description = description;
        }

        public void SetSurveyId (int surveyId) {
            SurveyId = surveyId;
        }

        public void AddQuestionAnswer (QuestionAnswer questionAnswer) {
            QuestionsAnswers.Add(questionAnswer);
        }
    }
}