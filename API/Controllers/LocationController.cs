using API.Attributes;
using API.DTO;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationIngestionService _locationIngestionService;

        public LocationController(ILocationIngestionService locationIngestionService)
        {
            _locationIngestionService = locationIngestionService;
        }

        [HttpPost]
        [ApiKey]
        public async Task<IActionResult> UpdateLocation(ParticleWebhookPayload webhookPayload)
        {
            await _locationIngestionService.IngestLocationUpdate(webhookPayload);
            return Ok();
        }
    }
}
