using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.Commands.SurveyAnswer
{
    public class SurveyAnswerToAdd
    {
        public string SurveyTitle { get; set; }
        public string Description { get; set; }
        public int SurveyId { get; set; }
        public ICollection<QuestionAnswerToAdd> Questions { get; set; }
    }
}