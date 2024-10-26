using API.Interfaces;
using Domain.Entities.v1;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly TxContext _txContext;

        public AssetRepository(TxContext txContext)
        {
            _txContext = txContext;
        }

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            return await _txContext.Assets.ToListAsync();
        }

        public async Task<Asset?> GetAssetByAssetCode(Guid assetCode)
        {
            return await _txContext.Assets.FirstOrDefaultAsync(asset => asset.AssetCode == assetCode);
        }

        public async Task<Asset?> GetAssetByFleetCode(Guid fleetCode)
        {
            return await _txContext.Assets.FirstOrDefaultAsync(asset => asset.Fleet.FleetCode == fleetCode);
        }

        public async Task<Asset?> GetAssetByParticleDeviceId(string particleDeviceId)
        {
            return await _txContext.Assets.FirstOrDefaultAsync(asset => asset.ParticleDeviceId == particleDeviceId);
        }

        public async Task AddAsset(Asset asset)
        {
            await _txContext.Assets.AddAsync(asset);
            await _txContext.SaveChangesAsync();
        }

        public async Task<Asset> UpdateAsset(Asset asset)
        {
            _txContext.Update(asset);
            await _txContext.SaveChangesAsync();
            return asset;
        }

        public async Task DeleteAssetByAssetCode(Guid assetCode)
        {
            var asset = await _txContext.Assets.FirstOrDefaultAsync(a => a.AssetCode == assetCode);

            if (asset == null)
            {
                throw new KeyNotFoundException($"No asset found for asset code: {assetCode}");
            }

            _txContext.Assets.Remove(asset);
        }
    }
}
