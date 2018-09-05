using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class Survey {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Answered { get; private set; }
        public ICollection<string> Answer { get; private set; }
        public ICollection<LinearScale> LinearScales { get; private set; }
        public ICollection<SingleChoice> SingleChoices { get; private set; }
        public ICollection<MultipleChoice> MultipleChoices { get; private set; }

        public Survey (string title)
        {
            Title = title;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsAnswered ()
        {
            Answered = true;
        }
    }
}