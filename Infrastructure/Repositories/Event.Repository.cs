using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Enum;
using SwimmingAppBackend.Infrastructure.Context;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface IEventRepository
    {
        Task<Guid?> GetEventIdByEventEnumAsync(EventEnum eventEnum);
    }

    public class EventRepository : IEventRepository
    {
        private readonly SwimmingAppDBContext _dbContext;

        public EventRepository(SwimmingAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid?> GetEventIdByEventEnumAsync(EventEnum eventEnum)
        {
            var foundEventId = await _dbContext.Events
                .Where(e => e.EventEnum == eventEnum)
                .Select(e => e.Id)
                .FirstOrDefaultAsync();

            if (foundEventId != Guid.Empty)
            {
                return foundEventId; ;
            }
            else
            {
                return null;
            }
        }
    }
}