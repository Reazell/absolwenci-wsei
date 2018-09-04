namespace CareerMonitoring.Core.Domains.Surveys
{
    public class LinearScale
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public string MinLabel { get; private set; }
        public string MaxLabel { get; private set; }
        public Survey Survey { get; private set; }
    }
}