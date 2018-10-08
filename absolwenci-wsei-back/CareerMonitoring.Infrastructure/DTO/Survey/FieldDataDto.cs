using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.DTO.Survey {
    public class FieldDataDto {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string MinLabel { get; set; }
        public string MaxLabel { get; set; }
        public string Input { get; set; }
        public ICollection<ChoiceOptionDto> ChoiceOptions { get; set; }
        public ICollection<RowDto> Rows { get; set; }
        public int InputValue { get; set; }

        public void IncrementInputValue () {
            InputValue++;
        }
    }
}