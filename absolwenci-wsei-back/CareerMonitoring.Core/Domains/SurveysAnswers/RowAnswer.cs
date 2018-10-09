using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.SurveysAnswers {
    public class RowAnswer {
        public int Id { get; private set; }
        public int RowPosition { get; private set; }
        public string Input { get; private set; }
        public int FieldDataAnswerId { get; private set; }
        public FieldDataAnswer FieldDataAnswer { get; private set; }
        public ICollection<RowChoiceOptionAnswer> RowChoiceOptionAnswers { get; private set; } = new List<RowChoiceOptionAnswer>();

        private RowAnswer () { }

        public RowAnswer (int rowPosition, string input) {
            RowPosition = rowPosition;
            Input = input;
        }

        public void AddChoiceOptionAnswer (RowChoiceOptionAnswer rowChoiceOptionAnswer)
        {
            RowChoiceOptionAnswers.Add(rowChoiceOptionAnswer);
        }
    }
}