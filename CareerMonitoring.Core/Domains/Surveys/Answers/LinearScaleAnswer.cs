using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Core.Domains.Surveys.Answers
{
    public class LinearScaleAnswer : Answer
    {
        public int MarkedValue { get; private set; }
        public LinearScale LinearScale { get; private set; }
        

        private LinearScaleAnswer () {}

        public LinearScaleAnswer (int markedValue)
        {
            MarkedValue = markedValue;
            QuestionType = "linearScale";
        }
    }
}