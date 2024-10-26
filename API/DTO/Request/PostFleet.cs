namespace API.DTO.Request
{
    public class PostFleet
    {
        public Guid? FleetCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
