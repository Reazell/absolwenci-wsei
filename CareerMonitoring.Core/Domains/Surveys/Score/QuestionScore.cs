namespace CareerMonitoring.Core.Domains.Surveys.Score
{
    public class QuestionScore
    {
         public int Id { get; private set; }
        public int QuestionPosition { get; private set; }
        public string Content { get; private set; }
        public string Select { get; private set; }
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }
        public FieldDataScore FieldData { get; private set; }

        private QuestionScore () {}

        public QuestionScore (Question question)
        {
            QuestionPosition = question.QuestionPosition;
            Content = question.Content;
            Select = question.Select;
        }
    }
}