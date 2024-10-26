using API.DTO.Request;
using Domain.Entities.v1;

namespace API.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> GetAssets();
        Task<Asset?> GetAsset(Guid assetCode);
        Task<Asset?> GetAssetByFleetCode(Guid fleetCode);
        Task<Asset?> GetAsset(string particleDeviceId);
        Task AddAsset(PostAsset postAsset);
        Task<Asset> UpdateAsset(PostAsset postAsset);
        Task UpsertAsset(PostAsset postAsset);
        Task DeleteAsset(Guid assetCode);
    }
}
