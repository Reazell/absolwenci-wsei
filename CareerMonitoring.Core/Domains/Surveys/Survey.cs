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

<<<<<<< HEAD
        public void AddQuestions (ICollection<Question> questions) {
            Questions = questions;
        }

=======
>>>>>>> 8dc40dcf6cdcc9a1b415a39540a1e1c425bc0005
        public void MarkAsAnswered () {
            Answered = true;
        }
    }
}