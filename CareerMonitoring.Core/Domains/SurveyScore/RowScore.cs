using System.Collections.Generic;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Core.Domains.SurveyScore {
    public class RowScore {
        public int Id { get; private set; }
        public int RowPosition { get; private set; }
        public string Input { get; private set; }
        public int FieldDataId { get; private set; }
        public FieldDataScore FieldData { get; private set; }

        public RowScore () { }

        public RowScore (Row row) {
            RowPosition = row.RowPosition;
            Input = row.Input;

        }
    }
}