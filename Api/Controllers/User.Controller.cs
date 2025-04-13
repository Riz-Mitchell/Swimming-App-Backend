using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Domain.Services;

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
        public async Task<ActionResult> GetUsers()
        {
            var foundUsers = await _userService.GetUsersByQuery();

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

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] CreateUserReqDTO createUserReqDTO)
        {
            // Check if DTO from body null
            if (createUserReqDTO == null)
            {
                return BadRequest();
            }

            // Save to database
            var newUser = await _userService.CreateUser(createUserReqDTO);

            return CreatedAtAction(nameof(newUser), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, [FromBody] UpdateUserReqDTO userUpdates)
        {
            var foundUser = await _userService.GetUserById(JwtRegisteredClaimNames.Sub);

            if (foundUser == null)
            {
                return Unauthorized();
            }

            var updatedUser = _userService.UpdateUser(JwtRegisteredClaimNames.Sub, userUpdates);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var foundUser = await _userService.GetUserById(JwtRegisteredClaimNames.Sub); ;
            if (foundUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(JwtRegisteredClaimNames.Sub);

            return NoContent();
        }
    }
}