using System;

namespace CareerMonitoring.Infrastructure.Commands.SurveyReport
{
    public class CreateSurveyReport
    {
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public string Description { get; set; }
    }
}