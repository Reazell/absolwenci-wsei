using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys.Answers;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;
using CareerMonitoring.Infrastructure.DTO;

namespace CareerMonitoring.Infrastructure.Services.Interfaces
{
    public interface IAnswerService
    {
        Task CreateAsync (string questionType, int markedValue, ICollection<string> markedAnswers, string rowTitle, string colTitle, string answer, string markedAnswer);
        Task DeleteAsync (int id);
        Task<IEnumerable<AnswerDto>> GetAllForQuestionAsync (int questionId);
        Task<AnswerDto> GetByIdAsync (int id);
    }
}