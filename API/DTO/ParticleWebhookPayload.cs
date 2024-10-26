using System.Text.Json.Serialization;

namespace API.DTO
{
    public class ParticleWebhookPayload
    {
        public string Event {  get; set; }
        public string Data { get; set; }
        public string CoreId { get; set; }

        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }
    }
}
