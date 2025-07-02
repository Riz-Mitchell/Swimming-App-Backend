using Microsoft.AspNetCore.Mvc;
using SwimmingAppBackend.Domain.Services;
using SwimmingAppBackend.Api.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using SwimmingAppBackend.Extensions;

namespace SwimmingAppBackend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FriendshipsController : ControllerBase
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipsController(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        private Guid GetCurrentUserId() =>
            Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        // POST: api/friendships
        [HttpPost]
        public async Task<ActionResult<GetFriendshipResDTO>> SendFriendRequest([FromBody] CreateFriendshipReqDTO req)
        {
            var requesterId = User.GetUserId(); // inferred from token
            if (requesterId == null)
            {
                return BadRequest("User ID is required.");
            }

            var result = await _friendshipService.SendFriendRequestAsync((Guid)requesterId, req.AddresseeId);
            return Ok(result);
        }

        // PUT: api/friendships/{id}/accept
        [HttpPut("{id}/accept")]
        public async Task<ActionResult> AcceptFriendRequest(Guid id)
        {
            var addresseeId = User.GetUserId(); // inferred from token
            if (addresseeId == null)
            {
                return BadRequest("User ID is required.");
            }
            await _friendshipService.AcceptFriendRequestAsync((Guid)addresseeId, id);
            return NoContent();
        }

        // DELETE: api/friendships/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFriendship(Guid id)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return BadRequest("User ID is required.");
            }
            bool success = await _friendshipService.RemoveFriendshipAsync(id, (Guid)userId);
            return success ? NoContent() : NotFound();
        }

        // // GET: api/friendships
        // [HttpGet]
        // public async Task<ActionResult<List<GetFriendshipResDTO>>> GetMyFriendships()
        // {
        //     var
        //     var result = await _friendshipService.GetAllForUserAsync(userId);
        //     return Ok(result);
        // }
    }
}
