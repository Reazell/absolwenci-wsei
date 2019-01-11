using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveysAnswers {
    public class SurveyAnswer {
        public int Id { get; private set; }
        public string SurveyTitle { get; private set; }
        public string SurveyDescription { get; private set; }
        public int SurveyId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<QuestionAnswer> QuestionsAnswers { get; private set; } = new List<QuestionAnswer>();

        private SurveyAnswer () { }

        public SurveyAnswer (string surveyTitle, string surveyDescription, int surveyId) {
            SetSurveyTitle(surveyTitle);
            SetSurveyDescription(surveyDescription);
            SetSurveyId(surveyId);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetSurveyTitle (string surveyTitle) {
            SurveyTitle = surveyTitle;
        }

        public void SetSurveyDescription (string surveDescription) {
            SurveyDescription = surveDescription;
        }

        public void SetSurveyId (int surveyId) {
            SurveyId = surveyId;
        }

        public void AddQuestionAnswer (QuestionAnswer questionAnswer) {
            QuestionsAnswers.Add(questionAnswer);
        }
    }
}