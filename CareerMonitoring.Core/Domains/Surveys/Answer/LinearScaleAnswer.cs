namespace CareerMonitoring.Core.Domains.Surveys.Answer
{
    public class LinearScaleAnswer
    {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set;}
        public int MarkedValue { get; private set; }
    }
}