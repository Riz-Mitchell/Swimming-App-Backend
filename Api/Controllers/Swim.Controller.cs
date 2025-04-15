using Microsoft.AspNetCore.Mvc;
using SwimmingAppBackend.Domain.Services;


namespace SwimmingAppBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimController : ControllerBase
    {
        private readonly ISwimService _swimService;

        public SwimController(ISwimService swimService)
        {
            _swimService = swimService;
        }

        // GET: api/swims
        [HttpGet]
        public async Task<ActionResult> GetSwims()
        {
            var foundSwims = await _swimService.GetSwimsByQueryAsync();



            return Ok(foundSwims);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSwim(Guid id)
        {
            var foundSwim = await _swimService.GetUserByIdAsync(id);

            if (foundSwim == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundSwim);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostSwim([FromBody] CreateSwimReqDTO createSwimReqDTO)
        {
            // Check if DTO from body null
            if (createSwimReqDTO == null)
            {
                return BadRequest();
            }

            var subClaim = User.FindFirst("sub")?.Value;

            if (Guid.TryParse(subClaim, out var userId))
            {
                var swim = await _swimService.CreateSwimAsync(createSwimReqDTO, userId);

                return Ok(swim);
            }
            else
            {
                return BadRequest("Invalid GUID in sub claim");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSwim(Guid id, [FromBody] UpdateSwimDTO updateSwimDTO)
        {
            if (updateSwimDTO == null)
            {
                return BadRequest();
            }

            var subClaim = User.FindFirst("sub")?.Value;

            var success = Guid.TryParse(subClaim, out var userId);

            if (!success)
            {
                return BadRequest("Invalid GUID in sub claim");
            }
            else
            {
                var foundSwim = await _swimService.GetSwimByIdAsync(id);

                if (foundSwim == null)
                {
                    return BadRequest("No swim found with the given ID");
                }

                var updatedSwim = await _swimService.UpdateSwimAsync(userId, updateSwimDTO);

                return Ok(updatedSwim);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSwim(Guid id)
        {
            var subClaim = User.FindFirst("sub")?.Value;

            if (!Guid.TryParse(subClaim, out var userId))
            {
                return BadRequest("Invalid user ID format.");
            }
            else
            {
                var foundSwim = await _swimService.GetSwimByIdAsync(id);

                if (foundSwim == null)
                {
                    return NotFound();
                }

                await _swimService.DeleteSwimAsync(id);
                return NoContent();
            }

        }
    }
}
