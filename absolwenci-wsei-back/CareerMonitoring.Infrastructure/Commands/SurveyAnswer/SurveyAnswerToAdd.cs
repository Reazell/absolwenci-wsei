using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.Commands.SurveyAnswer
{
    public class SurveyAnswerToAdd
    {
        public string SurveyTitle { get; set; }
        public string description { get; set; }
        public int SurveyId { get; set; }
        public ICollection<QuestionAnswerToAdd> Questions { get; set; }
    }
}