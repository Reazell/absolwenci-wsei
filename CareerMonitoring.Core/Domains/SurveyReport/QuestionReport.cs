using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.SurveyReport
{
    public class QuestionReport
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public string Select { get; private set; }
        public int AnswersNumber { get; private set; }
        public int SurveyReportId { get; private set; }
        [NotMapped]
        public ICollection<string> Labels { get; set; }
        public string LabelsList
        {
            get { return string.Join(",", Labels); }
            set { Labels = value.Split(',').ToList(); }
        }
        public SurveyReport SurveyReport { get; private set; }
        public ICollection<DataSet> DataSets { get; private set; }
    }
}