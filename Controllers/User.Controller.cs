using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Context;
using SwimmingAppBackend.Models;
using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Interfaces;
using SwimmingAppBackend.Mappers;

namespace SwimmingAppBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly SwimmingAppDBContext _context;
        private readonly IUserRepository _userRepo;

        public UserController(SwimmingAppDBContext context, IUserRepository userRepository)
        {
            _userRepo = userRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var foundUsers = await _userRepo.GetAllAsync();

            var userDtos = foundUsers.Select(user => user.MapGetUserDTO());

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);

            if (foundUser == null)
            {
                return NotFound();
            }
            else
            {
                var userDTO = foundUser.MapGetUserDTO();
                return Ok(userDTO);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] CreateUserDTO createUserDTO)
        {
            // Check if DTO from body null
            if (createUserDTO == null)
            {
                return BadRequest();
            }

            // Map CreateUserDTO to new User
            var createdUser = createUserDTO.MapCreateUserDTO();

            // Save to database
            await _userRepo.CreateAsync(createdUser);

            return CreatedAtAction(nameof(createdUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, UpdateUserDTO updateUserDTO)
        {
            if (updateUserDTO == null)
            {
                return BadRequest();
            }

            var updatedUser = await _userRepo.UpdateAsync(id, updateUserDTO);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser.MapGetUserDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);
            if (foundUser == null)
            {
                return NotFound();
            }

            await _userRepo.DeleteAsync(foundUser);
            return NoContent();
        }
    }
}