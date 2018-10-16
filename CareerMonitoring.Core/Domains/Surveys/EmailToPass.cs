namespace CareerMonitoring.Core.Domains.Surveys
{
    public class EmailToPass
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public int SurveyId { get; private set; }

        private EmailToPass (){}

        public EmailToPass(string email, int surveyId)
        {
            Email = email;
            SurveyId = surveyId;
        }
    }
}