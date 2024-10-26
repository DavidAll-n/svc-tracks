using NetTopologySuite.Geometries;

namespace API.DTO.WebSocket
{
    public class AssetUpdate
    {
        public Guid AssetCode { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }
        public decimal Speed { get; set; }
        public decimal Altitude { get; set; }
        public decimal Angle { get; set; }
        public DateTime ReadDateTime { get; set; }
    }
}
