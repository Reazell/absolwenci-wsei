namespace CareerMonitoring.Infrastructure.Commands.Survey
{
    public class LinearScaleQuestionToAdd
    {
        public string Content { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string MinLabel { get; set; }
        public string MaxLabel { get; set; }
    }
}