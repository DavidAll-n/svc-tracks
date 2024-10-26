using API.Interfaces;
using Domain.Entities.v1;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class FleetRepository : IFleetRepository
    {
        private readonly TxContext _txContext;

        public FleetRepository(TxContext txContext)
        {
            _txContext = txContext;
        }

        public async Task<IEnumerable<Fleet>> GetFleets()
        {
            return await _txContext.Fleets.ToListAsync();
        }

        public async Task<Fleet?> GetFleetByFleetCode(Guid fleetCode)
        {
            return await _txContext.Fleets.FirstOrDefaultAsync(fleet => fleet.FleetCode == fleetCode);
        }

        public async Task AddFleet(Fleet fleet)
        {
            await _txContext.Fleets.AddAsync(fleet);
            await _txContext.SaveChangesAsync();
        }

        public async Task<Fleet> UpdateFleet(Fleet fleet)
        {
            _txContext.Update(fleet);
            await _txContext.SaveChangesAsync();
            return fleet;
        }

        public async Task DeleteFleetByFleetCode(Guid fleetCode)
        {
            var fleet = await _txContext.Fleets.FirstOrDefaultAsync(f => f.FleetCode == fleetCode);

            if (fleet == null)
            {
                throw new KeyNotFoundException($"No fleet found for fleet code: {fleetCode}");
            }

            _txContext.Fleets.Remove(fleet);
        }
    }
}
