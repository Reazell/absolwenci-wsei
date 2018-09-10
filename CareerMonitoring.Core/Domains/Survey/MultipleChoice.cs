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
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }
        public string MarkedAnswersNames
        {
            get { return string.Join (",", _markedAnswersNames); }
            set { _markedAnswersNames = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _markedAnswersNames { get; set; }

        private MultipleChoice () {}

        public MultipleChoice (string content)
        {
            Content = content;
        }
    }
}