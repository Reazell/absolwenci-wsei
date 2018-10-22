using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IChoiceOptionRepository
    {
        Task AddAsync (ChoiceOption choiceOption);
    }
}