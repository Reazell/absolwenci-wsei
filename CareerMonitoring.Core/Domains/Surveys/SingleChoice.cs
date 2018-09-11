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
            private set { _answersOptions = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _answersOptions { get; private set; }
        public ICollection<Answer> Answers { get; private set; }

        private SingleChoice () {}

        public SingleChoice (string content, ICollection<string> answerOptions)
        {
            Content = content;
            _answersOptions = answerOptions;
        }

        public void AddAnswerOption (string answerOption)
        {
            _answersOptions.Add(answerOption);
        }
    }
}