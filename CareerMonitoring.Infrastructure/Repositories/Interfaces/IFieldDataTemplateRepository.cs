using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyTemplates;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IFieldDataTemplateRepository
    {
        Task AddAsync (FieldDataTemplate fieldDataTemplate);
        Task<FieldDataTemplate> GetByIdAsync (int id, bool isTracking = true);
    }
}