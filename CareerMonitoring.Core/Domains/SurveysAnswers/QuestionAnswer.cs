using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveysAnswers {
    public class QuestionAnswer {
        public int Id { get; private set; }
        public int QuestionPosition { get; private set; }
        public string Content { get; private set; }
        public string Select { get; private set; }
        public int SurveyAnswerId { get; private set; }
        public SurveyAnswer SurveyAnswer { get; private set; }
        public ICollection<FieldDataAnswer> FieldDataAnswers { get; private set; }
    }
}