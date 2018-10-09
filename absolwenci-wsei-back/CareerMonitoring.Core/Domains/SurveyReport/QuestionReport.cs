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
        public int QuestionPosition { get; private set; }
        public int SurveyReportId { get; private set; }
        [NotMapped]
        public ICollection<string> Labels { get; set; } = new List<string>();
        public string LabelsList
        {
            get => string.Join(",", Labels);
            set => Labels = value.Split(',').ToList();
        }
        public SurveyReport SurveyReport { get; private set; }
        public ICollection<DataSet> DataSets { get; private set; } = new List<DataSet> ();

        private QuestionReport () {}

        public QuestionReport (string content, string select, int answersNumber, int questionPosition)
        {
            Content = content;
            Select = select;
            AnswersNumber = answersNumber;
            QuestionPosition = questionPosition;
        }

        public void AddAnswer ()
        {
            AnswersNumber++;
        }

        public void AddLabel (string label)
        {
            Labels.Add(label);
        }

        public void AddDataSet (DataSet dataSet)
        {
            DataSets.Add(dataSet);
        }
    }
}