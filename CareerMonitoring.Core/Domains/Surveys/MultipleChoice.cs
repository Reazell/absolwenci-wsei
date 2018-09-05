using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.Surveys
{
    public class MultipleChoice
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        //public ICollection<string> MarkedAnswersNames { get; set; }
        public Survey Survey { get; private set; }
    }
}