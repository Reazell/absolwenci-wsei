using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Core.Domains.Surveys.Answers
{
    public class OpenQuestionAnswer : Answer
    {
        public string Answer { get; private set; }
        public OpenQuestion OpenQuestion { get; private set; }

        private OpenQuestionAnswer () {}

        public OpenQuestionAnswer (string answer)
        {
            Answer = answer;
            QuestionType = "openQuestion";
        }
    }
}