// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using SwimmingAppBackend.Models;
// using SwimmingAppBackend.Context;
// using System.Threading.Tasks;
// using System.Linq;

// namespace SwimmingAppBackend.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class SwimController : ControllerBase
//     {
//         private readonly SwimmingAppDBContext _context;

//         public SwimController(SwimmingAppDBContext context) => _context = context;

//         // GET: api/swims
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Swim>>> GetSwims()
//             => await _context.Swims.ToListAsync();

//         // GET: api/swim/{id}
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Swim>> GetSwim(int id)
//         {
//             var swim = await _context.Swims.FindAsync(id);

//             if (swim == null)
//             {
//                 return NotFound();
//             }

//             return swim;
//         }

//         // POST: api/swim
//         [HttpPost]
//         public async Task<ActionResult<Swim>> CreateSwim(Swim swim)
//         {
//             // Validate the swim model before adding to database
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             _context.Swims.Add(swim);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetSwim", new { id = swim.Id }, swim);
//         }

//         // PUT: api/swim/{id}
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateSwim(int id, Swim swim)
//         {
//             if (id != swim.Id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(swim).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!_context.Swims.Any(e => e.Id == id))
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

//         // DELETE: api/swim/{id}
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteSwim(int id)
//         {
//             var swim = await _context.Swims.FindAsync(id);
//             if (swim == null)
//             {
//                 return NotFound();
//             }

//             _context.Swims.Remove(swim);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }
//     }
// }
