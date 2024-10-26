using Domain.Entities.v1;

namespace API.Interfaces
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAssets();
        Task<Asset?> GetAssetByAssetCode(Guid assetCode);
        Task<Asset?> GetAssetByFleetCode(Guid fleetCode);
        Task<Asset?> GetAssetByParticleDeviceId(string particleDeviceId);
        Task AddAsset(Asset asset);
        Task<Asset> UpdateAsset(Asset asset);
        Task DeleteAssetByAssetCode(Guid assetCode);
    }
}
