using System;
using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Core.Domains.SurveyTemplates
{
    public class SurveyTemplate
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<QuestionTemplate> QuestionTemplates { get; private set; } = new List<QuestionTemplate> ();

        private SurveyTemplate () { }

        public SurveyTemplate (string title, string description) {
            SetTitle(title);
            
            CreatedAt = DateTime.UtcNow;
        }

        public void SetTitle (string title) {
            Title = title;
        }

        public void SetDescription (string description) {
            this.description = description;
        }

        public void AddQuestionTemplate (QuestionTemplate questionTemplate) {
            QuestionTemplates.Add (questionTemplate);
        }

        public void Update (string title) {
            SetTitle(title);
            CreatedAt = DateTime.UtcNow;
        }
    }
}