using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CareerMonitoring.Core.Domains.Surveys.Answers;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;

namespace CareerMonitoring.Core.Domains.Surveys
{
    public class MultipleChoice
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public int SurveyId { get; private set; }
        public string AnswersOptions
        {
            get { return string.Join (",", _answersOptions); }
            private set { _answersOptions = value.Split (',').ToList(); }
        }
        [NotMapped]
        public ICollection<string> _answersOptions { get; private set; }
        public Survey Survey { get; private set; }
        public ICollection<MultipleChoiceAnswer> MultipleChoiceAnswers { get; private set; }

        private MultipleChoice () {}

        public MultipleChoice (string content, ICollection<string> answersOptions)
        {
            Content = content;
            _answersOptions = answersOptions;
        }
    }
}