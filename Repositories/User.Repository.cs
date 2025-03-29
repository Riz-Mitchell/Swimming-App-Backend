using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Context;
using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Interfaces;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly SwimmingAppDBContext _context;

        public UserRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        public async Task CreateAsync(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateAsync(int id, UpdateUserDTO updateUserDTO)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return null;
            }

            if (updateUserDTO.PhoneNumber != null)
            {
                existingUser.PhoneNumber = updateUserDTO.PhoneNumber;
            }

            if (updateUserDTO.Age != null)
            {
                existingUser.Age = updateUserDTO.Age;
            }

            if (updateUserDTO.Email != null)
            {
                existingUser.Email = updateUserDTO.Email;
            }

            if (updateUserDTO.Name != null)
            {
                existingUser.Name = updateUserDTO.Name;
            }

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }

    }
}