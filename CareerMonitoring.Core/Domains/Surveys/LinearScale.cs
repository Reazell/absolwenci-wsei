namespace CareerMonitoring.Core.Domains.Surveys
{
    public class LinearScale
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public int MarkedValue { get; private set; }
        public string MinLabel { get; private set; }
        public string MaxLabel { get; private set; }
        public Survey Survey { get; private set; }

        private LinearScale () {}

        public LinearScale (string content, int minValue, int maxValue, string minLabel, string maxLabel)
        {
            Content = content;
            MinValue = minValue;
            MaxValue = maxValue;
            MinLabel = minLabel;
            MaxLabel = maxLabel;
        }
    }
}