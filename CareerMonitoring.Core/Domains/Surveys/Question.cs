using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys
{
    public class Question
    {
        public int Id { get; private set; }
        public int QuestionPosition { get; private set; }
        public string Content { get; private set; }
        public string Select { get; private set; }
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }
        public ICollection<FieldData> FieldData { get; private set; }

        private Question () {}

        public Question (int questionPosition, string select)
        {
            QuestionPosition = questionPosition;
            Select = select;
        }
    }
}