using System.Collections.Generic;
using CareerMonitoring.Infrastructure.Validators.Survey;

namespace CareerMonitoring.Infrastructure.Commands.SurveyAnswer
{
    public class QuestionAnswerToAdd
    {
        public int QuestionPosition { get; set; }
        public string Content { get; set; }
        public string Select { get; set; }
        public bool IsRequired { get; set; }
        [FieldDataValidator]
        public ICollection<FieldDataAnswerToAdd> FieldData { get; set; }
    }
}