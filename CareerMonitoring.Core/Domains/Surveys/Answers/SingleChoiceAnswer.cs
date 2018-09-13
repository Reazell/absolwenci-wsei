using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Core.Domains.Surveys.Answers
{
    public class SingleChoiceAnswer : Answer
    {
        public string MarkedAnswer { get; private set; }
        public SingleChoice SingleChoice { get; private set; }


        private SingleChoiceAnswer () {}

        public SingleChoiceAnswer (string markedAnswer)
        {
            MarkedAnswer = markedAnswer;
            QuestionType = "singleChoice";
        }
    }
}