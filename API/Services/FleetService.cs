using API.DTO.Request;
using API.Interfaces;
using Domain.Entities.v1;

namespace API.Services
{
    public class FleetService : IFleetService
    {
        private readonly IFleetRepository _fleetRepository;

        public FleetService(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<IEnumerable<Fleet>> GetFleets()
        {
            return await _fleetRepository.GetFleets();
        }

        public async Task<Fleet?> GetFleet(Guid fleetCode)
        {
            return await _fleetRepository.GetFleetByFleetCode(fleetCode);
        }

        public async Task AddFleet(PostFleet postFleet)
        {
            var fleet = new Fleet()
            {
                FleetCode = Guid.NewGuid(),
                Name = postFleet.Name,
                Description = postFleet.Description
            };

            await _fleetRepository.AddFleet(fleet);
        }

        public async Task<Fleet> UpdateFleet(PostFleet postFleet)
        {
            var existingFleet = await _fleetRepository.GetFleetByFleetCode(postFleet.FleetCode.Value);

            if (existingFleet == null)
            {
                throw new KeyNotFoundException($"No fleet found for fleet code: {postFleet.FleetCode}");
            }

            existingFleet.Name = postFleet.Name;
            existingFleet.Description = postFleet.Description;
            existingFleet.ModifiedDateTime = DateTime.UtcNow;

            return await _fleetRepository.UpdateFleet(existingFleet);
        }

        public async Task UpsertFleet(PostFleet postFleet)
        {
            if (postFleet.FleetCode.HasValue)
            {
                await UpdateFleet(postFleet);
            }
            else
            {
                await AddFleet(postFleet);
            }
        }

        public async Task DeleteFleet(Guid fleetCode)
        {
            await _fleetRepository.DeleteFleetByFleetCode(fleetCode);
        }
    }
}
