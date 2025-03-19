// using Microsoft.AspNetCore.Mvc;
// using SwimmingAppBackend.Models;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using SwimmingAppBackend.Context;
// using System.Linq;
// using System.Threading.Tasks;

// namespace SwimmingAppBackend.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UserController : ControllerBase
//     {
//         private readonly SwimmingAppDBContext _context;

//         // Injecting the context into the controller
//         public UserController(SwimmingAppDBContext context)
//         {
//             _context = context;
//         }

//         // GET: api/User
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<User>>> GetUsers()
//         {
//             // Retrieving all users including swimmers (TPH)
//             var users = await _context.Users.ToListAsync();
//             return Ok(users);
//         }

//         // GET: api/User/{id}
//         [HttpGet("{id}")]
//         public async Task<ActionResult<User>> GetUser(int id)
//         {
//             // Retrieving a specific user by id
//             var user = await _context.Users.FindAsync(id);

//             if (user == null)
//             {
//                 return NotFound();
//             }

//             return Ok(user);
//         }

//         // POST: api/User
//         [HttpPost]
//         public async Task<ActionResult<User>> PostUser(User user)
//         {
//             _context.Users.Add(user);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
//         }

//         // PUT: api/User/{id}
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutUser(int id, User user)
//         {
//             if (id != user.Id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(user).State = EntityState.Modified;
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         // DELETE: api/User/{id}
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteUser(int id)
//         {
//             var user = await _context.Users.FindAsync(id);

//             if (user == null)
//             {
//                 return NotFound();
//             }

//             _context.Users.Remove(user);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }
//     }
// }
