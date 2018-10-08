namespace CareerMonitoring.Core.Domains.Surveys
{
    public class SurveyUserIdentifier
    {
        public int Id { get; private set; }
        public string UserEmail { get; private set; }
        public int SurveyId { get; private set; }
        public bool Answered { get; private set; }

        private SurveyUserIdentifier () { }

        public SurveyUserIdentifier(string userEmail, int surveyId)
        {
            UserEmail = userEmail;
            SurveyId = surveyId;
        }
        
        public void MarkAsAnswered()
        {
            Answered = true;
        }
    }
}