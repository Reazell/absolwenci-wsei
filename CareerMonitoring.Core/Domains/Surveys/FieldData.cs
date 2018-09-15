using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys
{
    public class FieldData
    {
        public int Id { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public string MinLabel { get; private set; }
        public string MaxLabel { get; private set; }
        public string Input { get; private set; }
        public int QuestionId { get; private set; }
        public Question Question { get; private set;}
        public ICollection<ChoiceOption> ChoiceOptions { get; private set; }
        public ICollection<Row> Rows { get; private set; }

        private FieldData () {}

        public FieldData (ICollection<ChoiceOption> choiceOptions)
        {
            ChoiceOptions = choiceOptions;
        }

        public FieldData (string input)
        {
            Input = input;
        }

        public FieldData (int minValue, int maxValue, string minLabel, string maxLabel)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            MinLabel = minLabel;
            MaxLabel = maxLabel;
        }

        public FieldData (ICollection<Row> rows)
        {
            Rows = rows;
        }
    }
}