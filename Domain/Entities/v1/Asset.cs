using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.v1
{
    public class Asset : BaseEntity
    {
        public int AssetId { get; set; }
        public Guid AssetCode { get; set; }
        public string ParticleDeviceId { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public AssetType Type { get; set; }

        public int FleetId { get; set; }

        [ForeignKey(nameof(FleetId))]
        public virtual Fleet Fleet { get; set; }
    }
}
