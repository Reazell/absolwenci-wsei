using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.DTO
{
    public class SurveyDto
    {
        public string Title { get; set; }
        public bool Answered { get; set; }
        public ICollection<LinearScale> LinearScales { get; set; }
        public ICollection<SingleChoice> SingleChoices { get; set; }
        public ICollection<MultipleChoice> MultipleChoices { get; set; }
        public ICollection<OpenQuestion> OpenQuestions { get; set; }
    }
}