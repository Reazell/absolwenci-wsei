using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.Surveys.Score;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IReportService {
        Task<ICollection<LinearScaleScore>> CountLinearScaleAnswers (ICollection<LinearScale> linearScales);
        Task<ICollection<MultipleChoiceScore>> CountMultipleChoiceAnswers (ICollection<MultipleChoice> multipleChoices);
        Task<ICollection<MultipleGridScore>> CountMultipleGridAnswers (ICollection<MultipleGrid> multipleGrids);
        Task<List<SingleChoiceScore>> CountSingleChoiceAnswers (ICollection<SingleChoice> singleChoices);
        Task<ICollection<SingleGridScore>> CountSingleGridAnswers (ICollection<SingleGrid> singleGrids);

    }
}