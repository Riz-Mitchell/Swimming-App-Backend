using SwimmingAppBackend.Context;
using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Interfaces;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Repositories
{
    public class SwimmerMetaDataRepository : ISwimmerMetaDataRepository
    {

        private readonly SwimmingAppDBContext _context;

        public SwimmerMetaDataRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<SwimmerMetaData?> GetByIdAsync(int id)
        {
            var foundSwimmerMetaData = await _context.SwimmerMetaDatas.FindAsync(id);

            if (foundSwimmerMetaData == null)
            {
                return null;
            }

            return foundSwimmerMetaData;
        }

        public async
    }
}