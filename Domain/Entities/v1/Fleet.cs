namespace Domain.Entities.v1
{
    public class Fleet : BaseEntity
    {
        public int FleetId { get; set; }
        public Guid FleetCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Asset> Assets { get; set; }
    }
}
