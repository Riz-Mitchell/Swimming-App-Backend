using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface ITimeSheetRepository
    {
        Task<GetTimeSheetResDTO?> GetTimeSheetByIdAsync(Guid id);
        Task<GetTimeSheetResDTO> CreateTimeSheetAsync(CreateTimeSheetReqDTO createSchema);
        Task DeleteTimeSheetAsync(Guid id);
    }

    public class TimeSheetRepository : ITimeSheetRepository
    {

        private readonly SwimmingAppDBContext _context;

        public TimeSheetRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<GetTimeSheetResDTO?> GetTimeSheetByIdAsync(Guid id)
        {
            var foundTimeSheet = await _context.TimeSheets.FindAsync(id);

            if (foundTimeSheet == null)
            {
                return null;
            }
            var getTimeSheetResDTO = new GetTimeSheetResDTO
            {
                Id = foundTimeSheet.Id,
                Interval = foundTimeSheet.Interval,
                StartInterval = foundTimeSheet.StartInterval,
                Event = foundTimeSheet.Event,
                TimeSheetItems = [.. foundTimeSheet.TimeSheetItems.Select(item => new GetTimeSheetItemResDTO
                {
                    Id = item.Id,
                    Time = item.Time,
                    CurrentInterval = item.CurrentInterval,
                })]
            };

            return getTimeSheetResDTO;
        }

        public async Task<GetTimeSheetResDTO> CreateTimeSheetAsync(CreateTimeSheetReqDTO createSchema)
        {
            var timeSheet = new TimeSheet
            {
                Interval = createSchema.Interval,
                StartInterval = createSchema.StartInterval,
                Event = createSchema.Event,
            };

            timeSheet.TimeSheetItems = [.. createSchema.TimeSheetItems.Select(item => new TimeSheetItem
            {
                Time = item.Time,
                CurrentInterval = item.CurrentInterval,
                TimeSheetId = timeSheet.Id, // Set the required TimeSheetId property
                TimeSheet = timeSheet // Set the navigation property
            })];

            await _context.TimeSheets.AddAsync(timeSheet);
            await _context.SaveChangesAsync();

            return new GetTimeSheetResDTO
            {
                Id = timeSheet.Id,
                Interval = timeSheet.Interval,
                StartInterval = timeSheet.StartInterval,
                Event = timeSheet.Event,
                TimeSheetItems = [.. timeSheet.TimeSheetItems.Select(item => new GetTimeSheetItemResDTO
                {
                    Id = item.Id,
                    Time = item.Time,
                    CurrentInterval = item.CurrentInterval,
                })],
            };
        }

        public async Task DeleteTimeSheetAsync(Guid id)
        {
            var foundTimeSheet = await _context.TimeSheets.FindAsync(id);

            if (foundTimeSheet != null)
            {
                _context.TimeSheets.Remove(foundTimeSheet);
                await _context.SaveChangesAsync();
            }
        }
    }
}