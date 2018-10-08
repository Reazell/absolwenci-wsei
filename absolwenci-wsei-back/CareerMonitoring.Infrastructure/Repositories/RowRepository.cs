using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Infrastructure.Data;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Repositories
{
    public class RowRepository : IRowRepository
    {
        private readonly CareerMonitoringContext _context;
        public RowRepository (CareerMonitoringContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Row row)
        {
            await _context.Rows.AddAsync (row);
            await _context.SaveChangesAsync ();
        }

        public async Task<Row> GetByIdAsync (int id)
        {
            return await _context.Rows.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Row>> GetAllByFieldDataIdInOrderAsync(int fieldDataId, bool isTracking = true)
        {
            if(isTracking)
                return await Task.FromResult(_context.Rows.AsTracking().Where(x => x.FieldDataId == fieldDataId)
                    .OrderBy(q => q.RowPosition));
            return await Task.FromResult(_context.Rows.AsNoTracking().Where(x => x.FieldDataId == fieldDataId)
                .OrderBy(q => q.RowPosition));
        }

        public async Task<Row> GetByFieldDataIdAsync (int fieldDataId, int rowPosition, bool isTracking = true)
        {
            if(isTracking)
                return await _context.Rows.AsTracking().Where(x => x.FieldDataId == fieldDataId)
                    .Where(x => x.RowPosition == rowPosition).SingleOrDefaultAsync();
            return await _context.Rows.AsNoTracking().Where(x => x.FieldDataId == fieldDataId)
                .Where(x => x.RowPosition == rowPosition).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Row row)
        {
            _context.Rows.Update (row);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync(Row row)
        {
            _context.Rows.Update (row);
            await _context.SaveChangesAsync ();
        }
    }
}