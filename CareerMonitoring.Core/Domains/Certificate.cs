using System;

namespace CareerMonitoring.Core.Domains {
    public class Certificate {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime DateOfReceived { get; private set; }

        protected Certificate () { }
        
        public Certificate (string title, DateTime dateOfRecived) {
            Title = title;
            DateOfReceived = dateOfRecived;
        }
    }
}