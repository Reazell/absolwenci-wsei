using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveysAnswers {
    public class SurveyAnswer {
        public int Id { get; private set; }
        public string SurveyTitle { get; private set; }
        public int SurveyId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Answered { get; private set; }
        public ICollection<QuestionAnswer> QuestionsAnswers { get; private set; } = new List<QuestionAnswer>();

        private SurveyAnswer () { }

        public SurveyAnswer (string surveyTitle, int surveyId) {
            SurveyTitle = surveyTitle;
            SurveyId = surveyId;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddQuestionAnswer (QuestionAnswer questionAnswer) {
            QuestionsAnswers.Add(questionAnswer);
        }

    }
}