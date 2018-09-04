using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys
{
    public class MultipleChoice
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public ICollection<string> MarkedAnswersNames { get; private set; }
        public Survey Survey { get; private set; }
    }
}