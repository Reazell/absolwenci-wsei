using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class Survey {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Answered { get; private set; }
        public ICollection<Question> Questions { get; private set; }

        private Survey () { }

        public Survey (string title) {
            Title = title;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddQuestions (ICollection<Question> questions)
        {
            Questions = questions;
        }

        public void MarkAsAnswered ()
        {
            Answered = true;
        }
    }
}