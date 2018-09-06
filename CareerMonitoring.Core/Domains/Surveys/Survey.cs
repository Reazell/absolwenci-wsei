using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class Survey {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Answered { get; private set; }
        public ICollection<LinearScale> LinearScales { get; private set; }
        public ICollection<SingleChoice> SingleChoices { get; private set; }
        public ICollection<MultipleChoice> MultipleChoices { get; private set; }
        public ICollection<OpenQuestion> OpenQuestions { get; private set; }

        private Survey () {}

        public Survey (string title)
        {
            Title = title;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddLinearScale (LinearScale linearScale)
        {
            LinearScales.Add(linearScale);
        }

        public void AddSingleChoice (SingleChoice singleChoice)
        {
            SingleChoices.Add(singleChoice);
        }

        public void AddMultipleChoice (MultipleChoice multipleChoice)
        {
            MultipleChoices.Add(multipleChoice);
        }

        public void AddOpenQuestion (OpenQuestion openQuestion)
        {
            OpenQuestions.Add(openQuestion);
        }

        public void MarkAsAnswered ()
        {
            Answered = true;
        }
    }
}