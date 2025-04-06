using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Context;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly SwimmingAppDBContext _context;

        public UserController(SwimmingAppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var foundUsers = await _context.Users.ToListAsync();

            return Ok(foundUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var foundUser = await _context.Users.FindAsync(id);

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
        public async Task<ActionResult> PostUser([FromBody] User user)
        {
            // Check if DTO from body null
            if (user == null)
            {
                return BadRequest();
            }

            // Save to database
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(user), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var foundUser = await _context.Users.FindAsync(id);

            if (foundUser == null)
            {
                return NotFound();
            }

            foundUser.Name = user.Name ?? foundUser.Name;
            foundUser.Email = user.Email ?? foundUser.Email;
            foundUser.Age = user.Age ?? foundUser.Age;
            foundUser.PhoneNumber = user.PhoneNumber ?? foundUser.PhoneNumber;

            await _context.SaveChangesAsync();

            return Ok(foundUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var foundUser = await _context.Users.FindAsync(id);
            if (foundUser == null)
            {
                return NotFound();
            }

            _context.Users.Remove(foundUser);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}