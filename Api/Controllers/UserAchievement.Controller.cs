using Microsoft.AspNetCore.Mvc;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Extensions;
using SwimmingAppBackend.Domain.Services;

namespace SwimmingAppBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAchiementController : ControllerBase
    {
        private readonly IUserAchievementService _userAchievementService;

        public UserAchiementController(IUserAchievementService userAchievementService)
        {
            _userAchievementService = userAchievementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAchievements([FromQuery] UserAchievementsQuery querySchema)
        {
            // Check if user is trying to view another users achievements
            Guid reqUserId;

            if (querySchema.UserId == null)
            {
                reqUserId = User.GetUserId() ?? Guid.Empty;

                if (reqUserId == Guid.Empty)
                {
                    return BadRequest("Requires a UserId");
                }
                else
                {
                    querySchema.UserId = reqUserId;
                }
            }

            var userAchievements = await _userAchievementService.GetUserAchievementsAsync(querySchema);

            return Ok(userAchievements);
        }
    }
}