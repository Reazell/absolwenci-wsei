using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.Commands.SurveyAnswer
{
    public class FieldDataAnswerToAdd
    {
        public string Input { get; set; }
        public string MinLabel { get; set; }
        public string MaxLabel { get; set; }
        public ICollection<ChoiceOptionAnswerToAdd> ChoiceOptions { get; set; }
        public ICollection<RowAnswerToAdd> Rows { get; set; }
    }
}