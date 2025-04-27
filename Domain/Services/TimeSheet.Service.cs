using System.ComponentModel.Design;
using SwimmingAppBackend.Infrastructure.Repositories;

namespace SwimmingAppBackend.Domain.Services
{
    public interface ITimeSheetService
    {
        Task<double?> CalculatePercentageOffPB(Guid userId, Guid eventId, double time, double distance);
    }

    public class TimeSheetService : ITimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepository;

        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public TimeSheetService(ITimeSheetRepository timeSheetRepository, IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _timeSheetRepository = timeSheetRepository;
            _userService = userService;
        }

        public async Task<double?> CalculatePercentageOffPB(Guid userId, Guid eventId, double time, double distance)
        {
            var eventDetails = await _eventService.GetEventByIdAsync(eventId) ?? throw new Exception("Event not found");

            var timeSheet = await _timeSheetRepository.GetTimeSheetByIdAsync(eventDetails.TimeSheetId) ?? throw new Exception("TimeSheet not found");

            var user = await _userService.GetUserById(userId) ?? throw new Exception("User not found");

            var personalBest =
        }
    }
}