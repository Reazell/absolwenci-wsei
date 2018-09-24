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
        public int AnswersNumber { get; private set; } = 0;
        public int SurveyReportId { get; private set; }
        [NotMapped]
        public ICollection<string> Labels { get; set; }
        public string LabelsList
        {
            get => string.Join(",", Labels);
            set => Labels = value.Split(',').ToList();
        }
        public SurveyReport SurveyReport { get; private set; }
        public ICollection<DataSet> DataSets { get; private set; } = new List<DataSet> ();

        private QuestionReport () {}

        public QuestionReport (string content, string select, ICollection<string> labels)
        {
            Content = content;
            Select = select;
            Labels = labels;
        }

        public void AddAnswer ()
        {
            AnswersNumber++;
        }

        public void AddDataSet (DataSet dataSet)
        {
            DataSets.Add(dataSet);
        }
    }
}