using Domain.Enum;

namespace API.DTO.Request
{
    public class PostAsset
    {
        public Guid? AssetCode { get; set; }
        public string ParticleDeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AssetType Type { get; set; }
        public Guid FleetCode { get; set; }
    }
}
