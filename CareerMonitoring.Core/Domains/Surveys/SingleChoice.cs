using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CareerMonitoring.Core.Domains.Surveys
{
    public class SingleChoice
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public string MarkedAnswerName { get; private set; }
        public int SurveyId { get; private set; }
        public Survey Survey { get; private set; }
        public string AnswersOptions
        {
            get { return string.Join (",", _answersOptions); }
            set { _answersOptions = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _answersOptions { get; set; }

        private SingleChoice () {}

        public SingleChoice (string content)
        {
            Content = content;
        }

        public void AddAnswerOption (string answerOption)
        {
            _answersOptions.Add(answerOption);
        }

        public void MarkAnswerOption (string answerOption)
        {
            MarkedAnswerName = answerOption;
        }
    }
}