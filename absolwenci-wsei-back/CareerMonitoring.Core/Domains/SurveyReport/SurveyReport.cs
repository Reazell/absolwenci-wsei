using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveyReport
{
    public class SurveyReport
    {
        public int Id { get; private set; }
        public string SurveyTitle { get; private set; }
        public string SurveyDescription { get; private set; }
        public int AnswersNumber { get; private set; } = 0;
        public int SurveyId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<QuestionReport> QuestionsReports { get; private set; } = new List<QuestionReport>();

        private SurveyReport () {}

        public SurveyReport (int surveyId, string surveyTitle, string surveyDescription){
            SetSurveyId(surveyId);
            SetSurveyTitle(surveyTitle);
            SetSurveyDescription(surveyDescription);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetSurveyId (int surveyId) {
            SurveyId = surveyId;
        }

        public void SetSurveyTitle (string surveyTitle) {
            SurveyTitle = surveyTitle;
        }

        public void SetSurveyDescription (string surveyDescription) {
            SurveyDescription = surveyDescription;
        }

        public void AddQuestionReport (QuestionReport questionReport)
        {
            QuestionsReports.Add(questionReport);
        }

        public void AddAnswer()
        {
            AnswersNumber++;
        }

        public void Update(string surveyTitle, string surveyDescription)
        {
            SurveyTitle = surveyTitle;
            SurveyDescription = surveyDescription;
        }
    }
}