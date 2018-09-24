using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.SurveyReport
{
    public class DataSet
    {
        public int Id { get; private set; }
        public string Label { get; private set; }
        [NotMapped]
        public ICollection<string> _data { get; set; }
        public string Data
        {
            get { return string.Join(",", _data); }
            set { _data = value.Split(',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _colours { get; set; }
        public string ColoursList
        {
            get { return string.Join(",", _colours); }
            set { _colours = value.Split(',').ToList(); }
        }
        public int QuestionReportId { get; private set; }
        public QuestionReport QuestionReport { get; private set; }
    }
}