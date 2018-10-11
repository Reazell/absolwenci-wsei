using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class DataSetRepository : IDataSetRepository
    {
        private readonly CareerMonitoringContext _context;

        public DataSetRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DataSet dataSet)
        {
            await _context.DataSets.AddAsync (dataSet);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<DataSet>> GetByQuestionReportAsync(int questionReportId, bool isTracking = true)
        {
            if(isTracking){
                return await Task.FromResult(_context.DataSets
                    .AsTracking()
                    .Where(x => x.QuestionReportId == questionReportId));
            }
            return await Task.FromResult(_context.DataSets
                .AsNoTracking()
                .Where(x => x.QuestionReportId == questionReportId));
        }

        public async Task UpdateAsync(DataSet dataSet)
        {
            _context.DataSets.Update (dataSet);
            await _context.SaveChangesAsync ();
        }
        public async Task DeleteAsync(DataSet dataSet)
        {
            _context.DataSets.Remove (dataSet);
            await _context.SaveChangesAsync ();
        }
    }
}