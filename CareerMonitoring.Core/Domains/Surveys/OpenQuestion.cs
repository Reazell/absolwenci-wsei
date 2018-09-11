using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys
{
    public class OpenQuestion
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }
        public ICollection<Answer> Answers { get; private set; }

        private OpenQuestion () {}

        public OpenQuestion (string content)
        {
            Content = content;
        }
    }
}