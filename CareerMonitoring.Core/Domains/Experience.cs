using System;

namespace CareerMonitoring.Core.Domains {
    public class Experience {
        public int Id { get; private set; }
        public string Position { get; private set; }
        public string CompanyName { get; private set; }
        public string Location { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        protected Experience () { }

        public Experience (string position, string companyName, string location, DateTime from, DateTime to) {
            Position = position;
            CompanyName = companyName;
            Location = location;
            From = from;
            To = to;
        }
    }
}