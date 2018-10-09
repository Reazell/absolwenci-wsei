using System;
using System.Collections.Generic;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.DTO.Survey;

namespace CareerMonitoring.Infrastructure.DTO {
    public class SurveyDto {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Answered { get; set; }
        public ICollection<QuestionDto> Questions { get; set; }
    }
}