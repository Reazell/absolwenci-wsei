using System;
using System.Collections.Generic;

namespace CareerMonitoring.Core.Domains.Surveys {
    public class Survey {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<LinearScale> LinearScales { get; private set; }
        public ICollection<SingleChoice> SingleChoices { get; private set; }
        public ICollection<MultipleChoice> MultipleChoices { get; private set; }
        public ICollection<SingleGrid> SingleGrids { get; private set; }
        public ICollection<MultipleGrid> MultipleGrids { get; private set; }

        private Survey () { }

        public Survey (string title) {
            Title = title;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddLinearScale (LinearScale linearScale) {
            LinearScales.Add (linearScale);
        }
    }
}