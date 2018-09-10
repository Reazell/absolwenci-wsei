using System;
using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains {
    public class Certificate {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime DateOfReceived { get; private set; }
        public int AccountId { get; private set; }
        public Account Account { get; private set; }

        protected Certificate () { }

        public Certificate (string title, DateTime dateOfReceived) {
            Title = title;
            DateOfReceived = dateOfReceived;
        }
    }
}