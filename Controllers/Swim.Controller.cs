using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Models;
using SwimmingAppBackend.Context;
using System.Threading.Tasks;
using System.Linq;
using SwimmingAppBackend.Interfaces;
using System.IO.Pipelines;
using SwimmingAppBackend.Mappers;
using SwimmingAppBackend.DataTransferObjects;

namespace SwimmingAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimController : ControllerBase
    {
        private readonly SwimmingAppDBContext _context;

        private readonly ISwimRepository _swimRepo;

        private readonly ISwimmerMetaDataRepository _swimmerMetaDataRepo;

        public SwimController(SwimmingAppDBContext context, ISwimRepository swimRepo, ISwimmerMetaDataRepository swimmerMetaDataRepo)
        {
            _context = context;
            _swimmerMetaDataRepo = swimmerMetaDataRepo;
            _swimRepo = swimRepo;
        }

        // GET: api/swims
        [HttpGet]
        public async Task<ActionResult> GetSwims()
        {
            var foundSwims = await _swimRepo.GetAllAsync();

            var swimDtos = foundSwims.Select(swim => swim.MapGetSwimDTO());

            return Ok(swimDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSwim(int id)
        {
            var foundSwim = await _swimRepo.GetByIdAsync(id);

            if (foundSwim == null)
            {
                return NotFound();
            }
            else
            {
                var swimDTO = foundSwim.MapGetSwimDTO();
                return Ok(swimDTO);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostSwim([FromBody] CreateSwimDTO createSwimDTO)
        {
            // Check if DTO from body null
            if (createSwimDTO == null)
            {
                return BadRequest();
            }

            var foundSwimmerMetaData = await _swimmerMetaDataRepo.GetByIdAsync(createSwimDTO.SwimmerMetaDataId);

            if (foundSwimmerMetaData == null)
            {
                return NotFound("SwimmerMetaData doesn't exist");
            }

            // Map CreateUserDTO to new User
            var createdSwim = createSwimDTO.MapCreateSwimDTO(foundSwimmerMetaData);

            // Save to database
            await _swimRepo.CreateAsync(createdSwim);

            return CreatedAtAction(nameof(createdSwim), new { id = createdSwim.Id }, createdSwim);
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
