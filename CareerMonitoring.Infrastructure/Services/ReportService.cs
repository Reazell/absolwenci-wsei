using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.Surveys.Score;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services {
    public class ReportService : IReportService {

        public ReportService () {

        }
        public Task<ICollection<LinearScaleScore>> CountLinearScaleAnswers (ICollection<LinearScale> linearScales) {
            throw new System.NotImplementedException ();
        }

        public Task<ICollection<MultipleChoiceScore>> CountMultipleChoiceAnswers (ICollection<MultipleChoice> multipleChoices) {
            throw new System.NotImplementedException ();
        }

        public Task<ICollection<MultipleGridScore>> CountMultipleGridAnswers (ICollection<MultipleGrid> multipleGrids) {
            throw new System.NotImplementedException ();
        }

        public Task<List<SingleChoiceScore>> CountSingleChoiceAnswers (ICollection<SingleChoice> singleChoices) {

            var list = new List<SingleChoiceScore> ();
            foreach (var singleChoice in singleChoices) {

                var answerOptions = singleChoice.GetAnswersOption ().ToList ();
                int score = 0;
                string result = string.Empty;

                for (int i = 0; i < answerOptions.Count - 1; i++) {

                    var option = answerOptions[i];

                    foreach (var answers in singleChoice.SingleChoiceAnswers) {
                        if (option == answers.MarkedAnswer)
                            score++;
                    }
                    result += string.Format ($"Odpowiedż {option} została zaznaczona {score} razy. ");
                }
                var singleChoiceScore = new SingleChoiceScore (singleChoice, result);
                list.Add (singleChoiceScore);
                score = 0;
                result = string.Empty;
            }

            return Task.FromResult (list);
        }

        public Task<ICollection<SingleGridScore>> CountSingleGridAnswers (ICollection<SingleGrid> singleGrids) {
            throw new System.NotImplementedException ();
        }

    }
}