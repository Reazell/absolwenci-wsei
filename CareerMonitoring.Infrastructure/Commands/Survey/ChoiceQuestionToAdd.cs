using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.Commands.Survey
{
    public class ChoiceQuestionToAdd
    {
        public string Content { get; set; }
        public ICollection<string> AnswersOptions { get; set; }
    }
}