using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class Survey {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<Question> Questions { get; private set; } = new List<Question> ();

        private Survey () { }

        public Survey (string title, string description) {
            SetTitle(title);
            SetDescription(description);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetTitle (string title) {
            Title = title;
        }

        public void SetDescription (string description) {
            Description = description;
        }

        public void AddQuestion (Question question) {
            Questions.Add (question);
        }

        public void Update (string title, string description) {
            SetTitle(title);
            SetDescription(description);
            CreatedAt = DateTime.UtcNow;
        }
    }
}