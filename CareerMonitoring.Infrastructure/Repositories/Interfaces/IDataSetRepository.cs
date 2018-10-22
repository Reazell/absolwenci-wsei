using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;

namespace CareerMonitoring.Infrastructure.Repositories.Interfaces
{
    public interface IDataSetRepository
    {
        Task AddAsync (DataSet dataSet);
        Task UpdateAsync (DataSet dataSet);
    }
}