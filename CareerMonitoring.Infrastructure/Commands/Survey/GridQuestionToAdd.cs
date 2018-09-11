using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.Commands.Survey
{
    public class GridQuestionToAdd
    {
        public string Content { get; set; }
        public ICollection<string> Rows { get; set; }
        public ICollection<string> Cols { get; set; }
    }
}