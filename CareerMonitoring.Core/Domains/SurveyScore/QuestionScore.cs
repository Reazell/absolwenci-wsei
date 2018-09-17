using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Core.Domains.SurveyScore
{
    public class QuestionScore
    {
         public int Id { get; private set; }
        public int QuestionPosition { get; private set; }
        public string Content { get; private set; }
        public string Select { get; private set; }
        public int SurveyId { get; private set; }
        public SurveyScore Survey { get; private set; }
        public ICollection<FieldDataScore> FieldData { get; private set; } = new List<FieldDataScore>();

        protected QuestionScore () {}        

        // public QuestionScore (Question question)
        // {
        //     QuestionPosition = question.QuestionPosition;
        //     Content = question.Content;
        //     Select = question.Select;
        // }
    }
}