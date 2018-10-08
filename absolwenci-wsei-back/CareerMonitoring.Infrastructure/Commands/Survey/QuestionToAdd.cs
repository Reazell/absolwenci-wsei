using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.Commands.Survey
{
    public class QuestionToAdd
    {
        public int QuestionPosition { get; set; }
        public string Content { get; set; }
        public string Select { get; set; }
        public ICollection<FieldDataToAdd> FieldData { get; set; }
    }
}