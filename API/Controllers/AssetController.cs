using API.DTO.Request;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            return Ok(await _assetService.GetAssets());
        }

        [HttpGet("get-by-code")]
        public async Task<IActionResult> GetAsset(Guid assetCode)
        {
            return Ok(await _assetService.GetAsset(assetCode));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertAsset(PostAsset postAsset)
        {
            await _assetService.UpsertAsset(postAsset);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsset(Guid assetCode)
        {
            await _assetService.DeleteAsset(assetCode);
            return Ok();
        }
    }
}
