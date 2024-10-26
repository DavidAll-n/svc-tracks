using API.Interfaces;
using Domain.Entities.v1;
using Infrastructure;

namespace API.Repositories
{
    public class DataPointRepository : IDataPointRepository
    {
        private readonly TxContext _txContext;

        public DataPointRepository(TxContext txContext)
        {
            _txContext = txContext;
        }

        public async Task AddDataPoint(DataPoint dataPoint)
        {
            await _txContext.DataPoints.AddAsync(dataPoint);
            await _txContext.SaveChangesAsync();
        }
    }
}
