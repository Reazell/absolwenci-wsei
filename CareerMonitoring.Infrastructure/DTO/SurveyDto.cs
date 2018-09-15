using System.Collections.Generic;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.DTO
{
    public class SurveyDto
    {
        public string Title { get; set; }
        public bool Answered { get; set; }
    }
}