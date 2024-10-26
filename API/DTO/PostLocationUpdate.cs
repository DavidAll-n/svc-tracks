using NetTopologySuite.Geometries;

namespace API.DTO
{
    public class PostLocationUpdate
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public decimal Speed { get; set; }
        public decimal Altitude { get; set; }
        public decimal Angle { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
