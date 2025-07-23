using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Domain.Services;
using SwimmingAppBackend.Extensions;

namespace SwimmingAppBackend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers([FromQuery] string nameContains)
        {
            var foundUsers = await _userService.GetUsersByQuery(new GetUsersQuery
            {
                PageNumber = 1,
                NameContains = nameContains
            });

            return Ok(foundUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(Guid id)
        {
            var foundUser = await _userService.GetUserById(id);

            if (foundUser == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundUser);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] CreateUserReqDTO createUserReqDTO)
        {
            // Check if DTO from body null
            if (createUserReqDTO == null)
            {
                return BadRequest();
            }

            // Save to database
            GetUserResDTO? newUser = await _userService.CreateUser(createUserReqDTO);

            if (newUser == null) return Conflict("User with this phone number already exists.");

            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(Guid id, [FromBody] UpdateUserReqDTO userUpdates)
        {
            var userId = User.GetUserId();

            if (userId == null)
            {
                return BadRequest("User ID not found in claims");

            }

            var foundUser = await _userService.GetUserById((Guid)userId);

            if (foundUser == null)
            {
                return Unauthorized();
            }

            var updatedUser = _userService.UpdateUser((Guid)userId, userUpdates);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var userId = User.GetUserId();

            if (userId == null)
            {
                return BadRequest("User ID not found in claims");

            }

            if ((Guid)userId != id)
            {
                return BadRequest("User ID in token does not match the ID in the request.");
            }

            var foundUser = await _userService.GetUserById((Guid)userId);
            if (foundUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser((Guid)userId);

            return NoContent();
        }
    }
}
