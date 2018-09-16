using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Commands.Survey
{
    public class SurveyToAdd
    {
        public string Title { get; set; }
        public ICollection<QuestionToAdd> Questions { get; set; }
    }
}