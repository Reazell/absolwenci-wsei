namespace CareerMonitoring.Core.Domains.Surveys.Score {
    public class SingleChoiceScore {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public SingleChoice SingleChoice { get; private set; }
        public int SurveyScoreId { get; private set; }
        public SurveyScore SurveyScore { get; private set; }
        public string Result { get; private set; }

        public SingleChoiceScore (SingleChoice singlechoice, string result) {
            SingleChoice = singlechoice;
            Content = singlechoice.Content;
            Result = result;
        }
    }
}