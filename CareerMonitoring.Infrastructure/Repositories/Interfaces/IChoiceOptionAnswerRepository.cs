using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveysAnswers;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IChoiceOptionAnswerRepository
    {
        Task AddAsync (ChoiceOptionAnswer choiceOptionAnswer);
    }
}