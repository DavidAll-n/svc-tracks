using API.DTO.Request;
using API.Interfaces;
using Domain.Entities.v1;

namespace API.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IFleetRepository _fleetRepository;

        public AssetService(IAssetRepository assetRepository, IFleetRepository fleetRepository)
        {
            _assetRepository = assetRepository;
            _fleetRepository = fleetRepository;
        }

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            return await _assetRepository.GetAssets();
        }

        public async Task<Asset?> GetAsset(Guid assetCode)
        {
            return await _assetRepository.GetAssetByAssetCode(assetCode);
        }

        public async Task<Asset?> GetAssetByFleetCode(Guid fleetCode)
        {
            return await _assetRepository.GetAssetByFleetCode(fleetCode);
        }

        public async Task<Asset?> GetAsset(string particleDeviceId)
        {
            return await _assetRepository.GetAssetByParticleDeviceId(particleDeviceId);
        }

        public async Task AddAsset(PostAsset postAsset)
        {
            var fleet = await _fleetRepository.GetFleetByFleetCode(postAsset.FleetCode);

            var asset = new Asset()
            {
                AssetCode = Guid.NewGuid(),
                ParticleDeviceId = postAsset.ParticleDeviceId,
                Name = postAsset.Name,
                Description = postAsset.Description,
                Type = postAsset.Type,
                Fleet = fleet
            };

            await _assetRepository.AddAsset(asset);
        }

        public async Task<Asset> UpdateAsset(PostAsset postAsset)
        {
            var existingAsset = await _assetRepository.GetAssetByAssetCode(postAsset.AssetCode.Value);
            var fleet = await _fleetRepository.GetFleetByFleetCode(postAsset.FleetCode);
            
            if (existingAsset == null)
            {
                throw new KeyNotFoundException($"No asset found for asset code: {postAsset.AssetCode}");
            }

            existingAsset.Name = postAsset.Name;
            existingAsset.Description = postAsset.Description;
            existingAsset.Fleet = fleet;
            existingAsset.ParticleDeviceId = postAsset.ParticleDeviceId;
            existingAsset.ModifiedDateTime = DateTime.UtcNow;

            return await _assetRepository.UpdateAsset(existingAsset);
        }

        public async Task UpsertAsset(PostAsset postAsset)
        {
            if (postAsset.AssetCode.HasValue)
            {
                await UpdateAsset(postAsset);
            }
            else
            {
                await AddAsset(postAsset);
            }
        }

        public async Task DeleteAsset(Guid assetCode)
        {
            await _assetRepository.DeleteAssetByAssetCode(assetCode);
        }
    }
}
