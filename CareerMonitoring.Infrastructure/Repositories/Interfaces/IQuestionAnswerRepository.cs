using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IQuestionAnswerRepository {
        Task AddAsync (QuestionAnswer questionAnswer);
        Task<QuestionAnswer> GetByIdAsync (int id, bool isTracking = true);
    }
}