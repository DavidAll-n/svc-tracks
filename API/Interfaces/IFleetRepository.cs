using Domain.Entities.v1;

namespace API.Interfaces
{
    public interface IFleetRepository
    {
        Task<IEnumerable<Fleet>> GetFleets();
        Task<Fleet?> GetFleetByFleetCode(Guid fleetCode);
        Task AddFleet(Fleet fleet);
        Task<Fleet> UpdateFleet(Fleet fleet);
        Task DeleteFleetByFleetCode(Guid fleetCode);
    }
}
