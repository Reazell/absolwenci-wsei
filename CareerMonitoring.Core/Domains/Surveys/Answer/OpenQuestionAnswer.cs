namespace CareerMonitoring.Core.Domains.Surveys.Answer
{
    public class OpenQuestionAnswer
    {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionType { get; private set;}
        public string Answer { get; private set; }

        private OpenQuestionAnswer () {}

        public OpenQuestionAnswer (string answer)
        {
            Answer = answer;
            QuestionType = "openQuestion";
        }
    }
}