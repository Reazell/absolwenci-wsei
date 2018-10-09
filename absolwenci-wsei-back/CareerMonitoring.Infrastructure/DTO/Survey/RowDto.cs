using System.Collections.Generic;

namespace CareerMonitoring.Infrastructure.DTO.Survey {
    public class RowDto {
        public int RowPosition { get; set; }
        public string Input { get; set; }
         public FieldDataDto FieldData { get; private set; }
    }
}