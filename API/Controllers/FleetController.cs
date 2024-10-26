using API.DTO.Request;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FleetController : ControllerBase
    {
        private readonly IFleetService _fleetService;

        public FleetController(IFleetService fleetService)
        {
            _fleetService = fleetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFleets()
        {
            return Ok(await _fleetService.GetFleets());
        }

        [HttpGet("get-by-code")]
        public async Task<IActionResult> GetFleet(Guid fleetCode)
        {
            return Ok(await _fleetService.GetFleet(fleetCode));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertFleet(PostFleet postFleet)
        {
            await _fleetService.UpsertFleet(postFleet);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFleet(Guid fleetCode)
        {
            await _fleetService.DeleteFleet(fleetCode);
            return Ok();
        }
    }
}
