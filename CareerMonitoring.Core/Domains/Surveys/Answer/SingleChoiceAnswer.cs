namespace CareerMonitoring.Core.Domains.Surveys.Answer
{
    public class SingleChoiceAnswer
    {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set; }
        public string MarkedAnswer { get; private set; }
        private SingleChoiceAnswer () {}

        public SingleChoiceAnswer (string markedAnswer)
        {
            MarkedAnswer = markedAnswer;
            QuestionType = "singleChoice";
        }
    }
}