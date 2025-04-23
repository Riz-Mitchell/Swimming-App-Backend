using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface ISwimRepository
    {
        Task<List<GetSwimResDTO>> GetSwimsByQueryAsync(GetSwimsQuery query);
        Task<GetSwimResDTO?> GetSwimByIdAsync(Guid id);
        Task<GetSwimResDTO> CreateSwimAsync(CreateSwimReqDTO swimSchema);
        Task<GetSwimResDTO?> UpdateSwimAsync(Guid id, UpdateSwimReqDTO updateSchema);
        Task DeleteSwimAsync(Guid id);
    }


    public class SwimRepository : ISwimRepository
    {
        private readonly SwimmingAppDBContext _context;

        public SwimRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<List<GetSwimResDTO>> GetSwimsByQueryAsync(GetSwimsQuery query)
        {
            var foundSwims = await _context.Swims
                .Where(x => query.Distance != null && x.Distance == query.Distance)
                .Skip((query.PageNumber - 1) * 10)
                .Take(10)
                .ToListAsync();

            var getSwimResDTOs = foundSwims.Select(swim => new GetSwimResDTO
            {
                Id = swim.Id,
                Time = swim.Time,
                Stroke = swim.Stroke,
                Distance = swim.Distance,
                PercentageOffPB = swim.PercentageOffPB,
                PercentageOffGoalTime = swim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = swim.PercentageOffGoalStrokeRate,         // Need to implement these calculations
                PercentageOffGoalStrokeCount = swim.PercentageOffGoalStrokeCount,       // Need to implement these calculations
                StrokeRate = swim.StrokeRate,
                StrokeCount = swim.StrokeCount,
                Pace = swim.Pace,
                PerceivedExertion = swim.PerceivedExertion,
                Dive = swim.Dive,
                RecordedAt = swim.RecordedAt
            }).ToList();

            return getSwimResDTOs;
        }

        public async Task<GetSwimResDTO?> GetSwimByIdAsync(Guid id)
        {
            var foundSwim = await _context.Swims.FindAsync(id);

            if (foundSwim == null)
            {
                return null;
            }
            var getSwimResDTO = new GetSwimResDTO
            {
                Id = foundSwim.Id,
                Time = foundSwim.Time,
                Stroke = foundSwim.Stroke,
                Distance = foundSwim.Distance,
                PercentageOffPB = foundSwim.PercentageOffPB,
                PercentageOffGoalTime = foundSwim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = foundSwim.PercentageOffGoalStrokeRate,         // Need to implement these calculations
                PercentageOffGoalStrokeCount = foundSwim.PercentageOffGoalStrokeCount,       // Need to implement these calculations
                StrokeRate = foundSwim.StrokeRate,
                StrokeCount = foundSwim.StrokeCount,
                Pace = foundSwim.Pace,
                PerceivedExertion = foundSwim.PerceivedExertion,
                Dive = foundSwim.Dive,
                RecordedAt = foundSwim.RecordedAt
            };

            return getSwimResDTO;
        }

        public async Task<GetSwimResDTO> CreateSwimAsync(CreateSwimReqDTO swimSchema)
        {
            var swim = new Swim
            {
                Time = swimSchema.Time,
                Stroke = swimSchema.Stroke,
                Distance = swimSchema.Distance,
                StrokeRate = swimSchema.StrokeRate ?? null,
                StrokeCount = swimSchema.StrokeCount ?? null,
                Pace = swimSchema.Pace ?? null,
                PerceivedExertion = swimSchema.PerceivedExertion ?? null,
                Dive = swimSchema.Dive,
                RecordedAt = swimSchema.RecordedAt
            };
            _context.Swims.Add(swim);
            await _context.SaveChangesAsync();

            var getSwimResDTO = new GetSwimResDTO
            {
                Id = swim.Id,
                Time = swim.Time,
                Stroke = swim.Stroke,
                Distance = swim.Distance,
                PercentageOffPB = swim.PercentageOffPB,
                PercentageOffGoalTime = swim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = swim.PercentageOffGoalStrokeRate,         // Need to implement these calculations
                PercentageOffGoalStrokeCount = swim.PercentageOffGoalStrokeCount,       // Need to implement these calculations
                StrokeRate = swim.StrokeRate,
                StrokeCount = swim.StrokeCount,
                Pace = swim.Pace,
                PerceivedExertion = swim.PerceivedExertion,
                Dive = swim.Dive,
                RecordedAt = swim.RecordedAt
            };

            return getSwimResDTO;
        }

        public async Task<GetSwimResDTO?> UpdateSwimAsync(Guid id, UpdateSwimReqDTO updateSchema)
        {
            var foundSwim = await _context.Swims.FindAsync(id);

            if (foundSwim == null)
            {
                return null;
            }

            foundSwim.Time = updateSchema.Time ?? foundSwim.Time;
            foundSwim.Stroke = updateSchema.Stroke ?? foundSwim.Stroke;
            foundSwim.Distance = updateSchema.Distance ?? foundSwim.Distance;
            foundSwim.StrokeRate = updateSchema.StrokeRate ?? foundSwim.StrokeRate;
            foundSwim.StrokeCount = updateSchema.StrokeCount ?? foundSwim.StrokeCount;
            foundSwim.Pace = updateSchema.Pace ?? foundSwim.Pace;
            foundSwim.PerceivedExertion = updateSchema.PerceivedExertion ?? foundSwim.PerceivedExertion;
            foundSwim.Dive = updateSchema.Dive ?? foundSwim.Dive;

            _context.Swims.Update(foundSwim);
            await _context.SaveChangesAsync();

            var getSwimResDTO = new GetSwimResDTO
            {
                Id = foundSwim.Id,
                Time = foundSwim.Time,
                Stroke = foundSwim.Stroke,
                Distance = foundSwim.Distance,
                PercentageOffPB = foundSwim.PercentageOffPB,
                PercentageOffGoalTime = foundSwim.PercentageOffGoalTime,
                PercentageOffGoalStrokeRate = foundSwim.PercentageOffGoalStrokeRate,         // Need to implement these calculations
                PercentageOffGoalStrokeCount = foundSwim.PercentageOffGoalStrokeCount,       // Need to implement these calculations
                StrokeRate = foundSwim.StrokeRate,
                StrokeCount = foundSwim.StrokeCount,
                Pace = foundSwim.Pace,
                PerceivedExertion = foundSwim.PerceivedExertion,
                Dive = foundSwim.Dive,
                RecordedAt = foundSwim.RecordedAt
            };

            return getSwimResDTO;
        }

        public async Task DeleteSwimAsync(Guid id)
        {
            var foundSwim = await _context.Swims.FindAsync(id);

            if (foundSwim != null)
            {
                _context.Swims.Remove(foundSwim);
                await _context.SaveChangesAsync();
            }
        }
    }
}