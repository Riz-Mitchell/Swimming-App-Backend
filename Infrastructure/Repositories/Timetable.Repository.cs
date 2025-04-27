using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface ITimetableRepository
    {
        Task<List<GetTimetableResDTO>> GetTimetablesByQueryAsync(GetTimetablesQuery query);
        Task<GetTimetableResDTO?> GetTimetableByIdAsync(Guid id);
        Task<GetTimetableResDTO> CreateTimetableAsync(CreateTimetableReqDTO timetableSchema);
        Task<GetTimetableResDTO?> UpdateTimetableAsync(Guid id, UpdateTimetableReqDTO updateSchema);
        Task DeleteTimetableAsync(Guid id);
    }

    public class TimetableRepository : ITimetableRepository
    {
        private readonly SwimmingAppDBContext _context;

        public TimetableRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<List<GetTimetableResDTO>> GetTimetablesByQueryAsync(GetTimetablesQuery query)
        {
            var foundTimetables = await _context.Timetables
                .Where(x => query.NameContains != null && x.Name.Contains(query.NameContains))
                .Skip((query.PageNumber - 1) * 10)
                .Take(10)
                .ToListAsync();

            var getTimetableResDTOs = foundTimetables.Select(timetable => new GetTimetableResDTO
            {
                Id = timetable.Id,
                Name = timetable.Name,
                StartDate = timetable.StartDate,
                EndDate = timetable.EndDate,
                CreatedAt = timetable.CreatedAt,
                SquadId = timetable.SquadId,
            }).ToList();

            return getTimetableResDTOs;
        }

        public async Task<GetTimetableResDTO?> GetTimetableByIdAsync(Guid id)
        {
            var foundTimetable = await _context.Timetables.FindAsync(id);

            if (foundTimetable == null)
            {
                return null;
            }
            var getTimetableResDTO = new GetTimetableResDTO
            {
                Id = foundTimetable.Id,
                Name = foundTimetable.Name,
                StartDate = foundTimetable.StartDate,
                EndDate = foundTimetable.EndDate,
                CreatedAt = foundTimetable.CreatedAt,
                SquadId = foundTimetable.SquadId,
            };

            return getTimetableResDTO;
        }

        public async Task<GetTimetableResDTO> CreateTimetableAsync(CreateTimetableReqDTO timetableSchema)
        {
            var foundSquad = await _context.Squads.FindAsync(timetableSchema.SquadId);
            if (foundSquad == null)
            {
                throw new Exception("Squad not found");
            }



            var newTimetable = new Timetable
            {
                Name = timetableSchema.Name,
                StartDate = timetableSchema.StartDate,
                EndDate = timetableSchema.EndDate,
                CreatedAt = DateTime.UtcNow,
                SquadId = timetableSchema.SquadId,
                Squad = foundSquad,
            };

            await _context.Timetables.AddAsync(newTimetable);
            await _context.SaveChangesAsync();

            var getTimetableResDTO = new GetTimetableResDTO
            {
                Id = newTimetable.Id,
                Name = newTimetable.Name,
                StartDate = newTimetable.StartDate,
                EndDate = newTimetable.EndDate,
                CreatedAt = newTimetable.CreatedAt,
            };

            return getTimetableResDTO;
        }

        public async Task<GetTimetableResDTO?> UpdateTimetableAsync(Guid id, UpdateTimetableReqDTO updateSchema)
        {
            var foundTimetable = await _context.Timetables.FindAsync(id);

            if (foundTimetable == null)
            {
                return null;
            }
            foundTimetable.SquadId = updateSchema.SquadId ?? foundTimetable.SquadId;
            foundTimetable.Name = updateSchema.Name ?? foundTimetable.Name;
            foundTimetable.StartDate = updateSchema.StartDate ?? foundTimetable.StartDate;
            foundTimetable.EndDate = updateSchema.EndDate ?? foundTimetable.EndDate;

            await _context.SaveChangesAsync();

            var getTimetableResDTO = new GetTimetableResDTO
            {
                Id = foundTimetable.Id,
                Name = foundTimetable.Name,
                StartDate = foundTimetable.StartDate,
                EndDate = foundTimetable.EndDate,
                CreatedAt = foundTimetable.CreatedAt,
            };

            return getTimetableResDTO;
        }
    }
}