using System.Collections.Generic;
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

        public Task<ICollection<SingleChoiceScore>> CountSingleChoiceAnswers (ICollection<SingleChoice> singleChoices) {
            throw new System.NotImplementedException ();
        }

        public Task<ICollection<SingleGridScore>> CountSingleGridAnswers (ICollection<SingleGrid> singleGrids) {
            throw new System.NotImplementedException ();
        }
    }
}