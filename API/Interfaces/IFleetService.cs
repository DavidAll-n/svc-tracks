using API.DTO.Request;
using Domain.Entities.v1;

namespace API.Interfaces
{
    public interface IFleetService
    {
        Task<IEnumerable<Fleet>> GetFleets();
        Task<Fleet?> GetFleet(Guid fleetCode);
        Task AddFleet(PostFleet postFleet);
        Task<Fleet> UpdateFleet(PostFleet postFleet);
        Task UpsertFleet(PostFleet postFleet);
        Task DeleteFleet(Guid fleetCode);
    }
}
