using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.Commands.Survey
{
    public class SurveyToUpdate
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<QuestionToAdd> Questions { get; set; }
    }
}