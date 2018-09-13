using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys.Score {
    public class LinearScaleScore {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public LinearScale LinearScale { get; private set; }
        public int SurveyScoreId { get; private set; }
        public SurveyScore SurveyScore { get; private set; }

        public LinearScaleScore (LinearScale linearScale) {
            LinearScale = linearScale;
            Content = linearScale.Content;
        }
    }
}