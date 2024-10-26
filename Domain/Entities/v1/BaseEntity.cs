namespace Domain.Entities.v1
{
    public class BaseEntity
    {
        public DateTime CreateDateTime { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        public DateTime ModifiedDateTime { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
    }
}