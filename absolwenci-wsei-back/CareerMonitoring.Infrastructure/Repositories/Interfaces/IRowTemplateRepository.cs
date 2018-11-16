using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IRowTemplateRepository
    {
        Task AddAsync (RowTemplate rowTemplate);
    }
}