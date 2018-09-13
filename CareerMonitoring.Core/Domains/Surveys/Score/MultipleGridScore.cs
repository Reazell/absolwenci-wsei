namespace CareerMonitoring.Core.Domains.Surveys.Score {
    public class MultipleGridScore {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public int SurveyScoreId { get; private set; }
        public SurveyScore SurveyScore { get; private set; }
    }
}