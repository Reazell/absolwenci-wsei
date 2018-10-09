using System;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Experience {
        public int Id { get; private set; }
        public string Position { get; private set; }
        public string CompanyName { get; private set; }
        public string Location { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public bool IsCurrentJob { get; private set; }
        public int AccountId { get; private set; }
        public Account Account { get; private set; }

        protected Experience () { }

        public Experience (string position, string companyName, string location,
            DateTime from, DateTime to, bool isCurrentJob) {
            Position = position;
            CompanyName = companyName;
            Location = location;
            From = from;
            To = to;
            IsCurrentJob = isCurrentJob;
        }
    }
}