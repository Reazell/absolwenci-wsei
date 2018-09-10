using System.Collections.Generic;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.DTO {
    public class SurveyDto {
        public string Title { get; private set; }
        public bool Answered { get; private set; }
        public ICollection<LinearScale> LinearScales { get; private set; }
        public ICollection<SingleChoice> SingleChoices { get; private set; }
        public ICollection<MultipleChoice> MultipleChoices { get; private set; }
        public ICollection<SingleGrid> SingleGrids { get; private set; }
        public ICollection<MultipleGrid> MultipleGrids { get; private set; }
        public ICollection<OpenQuestion> OpenQuestions { get; private set; }
    }
}