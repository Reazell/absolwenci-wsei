using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class Survey {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Answered { get; private set; }
        // public ICollection<LinearScale> LinearScales { get; private set; } = new List<LinearScale>();
        // public ICollection<SingleChoice> SingleChoices { get; private set; } = new List<SingleChoice>();
        // public ICollection<MultipleChoice> MultipleChoices { get; private set; } = new List<MultipleChoice>();
        // public ICollection<OpenQuestion> OpenQuestions { get; private set; } = new List<OpenQuestion>();
        // public ICollection<SingleGrid> SingleGrids { get; private set; } = new List<SingleGrid>();
        // public ICollection<MultipleGrid> MultipleGrids { get; private set; } = new List<MultipleGrid>();
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

        // public void AddLinearScale (LinearScale linearScale)
        // {
        //     LinearScales.Add(linearScale);
        // }

        // public void AddSingleChoice (SingleChoice singleChoice)
        // {
        //     SingleChoices.Add(singleChoice);
        // }

        // public void AddMultipleChoice (MultipleChoice multipleChoice)
        // {
        //     MultipleChoices.Add(multipleChoice);
        // }

        // public void AddOpenQuestion (OpenQuestion openQuestion)
        // {
        //     OpenQuestions.Add(openQuestion);
        // }

        // public void AddSingleGrid (SingleGrid singleGrid)
        // {
        //     SingleGrids.Add(singleGrid);
        // }

        // public void AddMultipleGrid (MultipleGrid multipleGrid)
        // {
        //     MultipleGrids.Add(multipleGrid);
        // }

        public void MarkAsAnswered ()
        {
            Answered = true;
        }
    }
}