using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces {
    public interface IQuestionTemplateRepository {
        Task AddAsync (QuestionTemplate questionTemplate);
        Task<QuestionTemplate> GetByIdAsync (int id, bool isTracking = true);
        Task DeleteAsync (QuestionTemplate questionTemplate);
    }
}