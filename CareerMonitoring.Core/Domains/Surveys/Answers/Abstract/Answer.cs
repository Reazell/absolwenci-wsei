namespace CareerMonitoring.Core.Domains.Surveys.Answers.Abstract
{
    public abstract class Answer
    {
        public int Id { get; protected set; }
        public int QuestionId { get; protected set; }
        public string QuestionType { get; protected set; }

        public Answer () {}
    }
}