// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc;
// using SwimmingAppBackend;
// using SwimmingAppBackend.context;

// namespace SwimmingAppBackend.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UserController : ControllerBase
//     {
//         private readonly SwimmingAppDBContext _context;

//         public UserController(SwimmingAppDBContext context) => _context = context;

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<UserController>>> GetUsers() => await _context.Users.ToListAsync();


//     }
// }