using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IChoiceOptionTemplateRepository
    {
        Task AddAsync (ChoiceOptionTemplate choiceOptionTemplate);
    }
}