using API.DTO;

namespace API.Interfaces
{
    public interface ILocationIngestionService
    {
        Task IngestLocationUpdate(ParticleWebhookPayload locationUpdate);
    }
}
