using Domain.Entities.v1;

namespace API.Interfaces
{
    public interface IDataPointRepository
    {
        Task AddDataPoint(DataPoint dataPoint);
    }
}
