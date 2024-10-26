using NetTopologySuite.Geometries;

namespace Domain.Entities.v1
{
    public class DataPoint : BaseEntity
    {
        public long DataPointId { get; set; }
        public Point Location { get; set; }
        public decimal Speed { get; set; }
        public decimal Altitude { get; set; }
        public decimal Angle { get; set; }
        public DateTime ReadDateTime { get; set; }
        public Asset Asset { get; set; }
    }
}
