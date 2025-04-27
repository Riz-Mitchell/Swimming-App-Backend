using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Infrastructure.Context;

namespace SwimmingAppBackend.Infrastructure.Repositories
{
    public interface IAthleteDataRepository
    {
        Task<Guid?> GetAthleteDataOwnerIdByUserIdAsync(Guid userId);
    }

    public class AthleteDataRepository : IAthleteDataRepository
    {
        private readonly SwimmingAppDBContext _context;

        public AthleteDataRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<Guid?> GetAthleteDataOwnerIdByUserIdAsync(Guid userId)
        {
            var foundAthleteDataOwnerId = await _context.AthleteDatas
                .Where(ad => ad.UserOwnerId == userId)
                .Select(e => e.Id)
                .FirstOrDefaultAsync();

            if (foundAthleteDataOwnerId == Guid.Empty)
            {
                return foundAthleteDataOwnerId; ;
            }
            else
            {
                return null;
            }
        }
    }
}