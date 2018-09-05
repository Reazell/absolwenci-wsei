using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys
{
    public class SingleChoice
    {
        public int Id { get; private set; }
        public int SurveyId { get; private set; }
        public string Content { get; private set; }
        public string MarkedAnswerName { get; private set; }
        public Survey Survey { get; private set; }

        private SingleChoice () {}

        public SingleChoice (string content)
        {
            Content = content;
        }
    }
}