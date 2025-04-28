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

            var foundUser = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
            Console.WriteLine($"Athlete data in found user:\n {foundUser.AthleteDataId}");

            var foundAthleteDataOwnerId = await _context.AthleteDatas
                .Where(ad => ad.UserOwnerId == userId)
                .Select(e => e.Id)
                .FirstOrDefaultAsync();

            Console.WriteLine($"Found AthleteDataOwnerId: {foundAthleteDataOwnerId} for UserId: {userId}");

            if (foundAthleteDataOwnerId != Guid.Empty)
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