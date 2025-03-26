// using Microsoft.AspNetCore.Http.HttpResults;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using SwimmingAppBackend.Context;
// using SwimmingAppBackend.Models;
// using SwimmingAppBackend.Data;

// namespace SwimmingAppBackend.Controllers
// {

//     [ApiController]
//     [Route("api/[controller]")]
//     public class UserController : ControllerBase
//     {
//         private readonly SwimmingAppDBContext _context;

//         public UserController(SwimmingAppDBContext context)
//         {
//             _context = context;
//         }

//         [HttpGet]
//         public async Task<ActionResult> GetUsers()
//         {
//             var foundUsers = await _context.users.ToListAsync();

//             if (foundUsers.Count == 0)
//             {
//                 return NotFound();
//             }
//             else
//             {
//                 return Ok(foundUsers);
//             }
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult> GetUser(int id)
//         {
//             var foundUser = await _context.users.FindAsync(id);

//             if (foundUser == null)
//             {
//                 return NotFound();
//             }
//             else
//             {
//                 var userDTO = new GetUserDTO
//                 {
//                     id = foundUser.id,
//                     name = foundUser.name
//                 };
//                 return Ok(userDTO);
//             }
//         }

//         [HttpPost]
//         public async Task<ActionResult> PostUser([FromBody] CreateUserDTO userDTO)
//         {
//             if (userDTO == null)
//             {
//                 return BadRequest();
//             }

//             var newUser = new User
//             {
//                 phoneNum = userDTO.phoneNum,
//                 name = userDTO.name
//             };

//             if (userDTO.age != null)
//             {
//                 newUser.age = userDTO.age;
//             }

//             if (userDTO.email != null)
//             {
//                 newUser.email = userDTO.email;
//             }

//             _context.users.Add(newUser);

//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetUser), new { id = newUser.id }, newUser);
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutUser(int id, User user)
//         {
//             if (id != user.id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(user).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!_context.users.Any(e => e.id == id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteUser(int id)
//         {
//             var foundUser = await _context.users.FindAsync(id);
//             if (foundUser == null)
//             {
//                 return NotFound();
//             }

//             _context.users.Remove(foundUser);
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }
//     }
// }