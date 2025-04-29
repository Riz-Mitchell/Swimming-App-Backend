using Microsoft.AspNetCore.Mvc;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Domain.Services;
using SwimmingAppBackend.Extensions;


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

        [HttpGet("{swimId}")]
        public async Task<ActionResult> GetSwim(Guid swimId)
        {

            var foundSwim = await _swimService.GetSwimByIdAsync(swimId);

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
            var userId = User.GetUserId();

            if (userId == null)
            {
                return BadRequest("User ID not found in claims");

            }

            Console.WriteLine($"User ID: {userId}");


            var swim = await _swimService.CreateSwimAsync((Guid)userId, createSwimReqDTO);

            if (swim == null)
            {
                return BadRequest("Failed to create swim");
            }
            else
            {
                return CreatedAtAction(nameof(GetSwim), new { swimId = swim.Id }, swim);
            }
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult> PutSwim(Guid id, [FromBody] UpdateSwimDTO updateSwimDTO)
        // {
        //     var userId = User.GetUserId();

        //     if (userId == null)
        //     {
        //         return BadRequest("User ID not found in claims");
        //     }

        //     var foundSwim = await _swimService.GetSwimByIdAsync(id);

        //     if (foundSwim == null)
        //     {
        //         return BadRequest("No swim found with the given ID");
        //     }

        //     var updatedSwim = await _swimService.UpdateSwimAsync(userId, updateSwimDTO);

        //     return Ok(updatedSwim);
        // }


        [HttpDelete("{swimId}")]
        public async Task<IActionResult> DeleteSwim(Guid swimId)
        {
            var userId = User.GetUserId();

            if (userId == null)
            {
                return BadRequest("User ID not found in claims");
            }

            await _swimService.DeleteSwimAsync(swimId, (Guid)userId);
            return NoContent();
        }

    }
}

