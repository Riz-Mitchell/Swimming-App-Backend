using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Context;
using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Interfaces;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Repositories
{
    public class SwimRepository : ISwimRepository
    {

        private readonly SwimmingAppDBContext _context;

        public SwimRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Swim>> GetAllAsync()
        {
            return await _context.Swims.ToListAsync();
        }

        public async Task<Swim?> GetByIdAsync(int id)
        {
            return await _context.Swims.FindAsync(id);
        }


        public async Task CreateAsync(Swim swim)
        {
            _context.Swims.Add(swim);

            await _context.SaveChangesAsync();
        }

        public async Task<Swim?> UpdateAsync(int id, UpdateSwimDTO updateSwimDTO)
        {
            var existingSwim = await _context.Swims.FindAsync(id);

            if (existingSwim == null)
            {
                return null;
            }

            if (updateSwimDTO.Time != null)
            {
                updateSwimDTO.Time = updateSwimDTO.Time;
            }

            if (updateSwimDTO.Stroke != null)
            {
                updateSwimDTO.Stroke = updateSwimDTO.Stroke;
            }

            if (updateSwimDTO.Distance != null)
            {
                updateSwimDTO.StrokeRate = updateSwimDTO.StrokeRate;
            }

            if (updateSwimDTO.Pace != null)
            {
                updateSwimDTO.Pace = updateSwimDTO.Pace;
            }

            if (updateSwimDTO.PerceivedExertion != null)
            {
                updateSwimDTO.PerceivedExertion = updateSwimDTO.PerceivedExertion;
            }

            if (updateSwimDTO.Dive != null)
            {
                updateSwimDTO.Dive = updateSwimDTO.Dive;
            }

            await _context.SaveChangesAsync();
            return existingSwim;
        }

        public async Task DeleteAsync(Swim swim)
        {
            _context.Swims.Remove(swim);

            await _context.SaveChangesAsync();
        }

    }
}