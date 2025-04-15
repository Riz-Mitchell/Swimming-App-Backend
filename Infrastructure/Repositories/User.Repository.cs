using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Infrastructure.Context;
using SwimmingAppBackend.Infrastructure.Models;

namespace SwimmingAppBackend.Domain.Services
{
    public interface IUserRepository
    {
        Task<List<GetUserResDTO>> GetUsersByQueryAsync(GetUsersQuery query);
        Task<GetUserResDTO?> GetUserByIdAsync(Guid id);
        Task<GetUserResDTO> CreateUserAsync(CreateUserReqDTO userSchema);
        Task<GetUserResDTO?> UpdateUserAsync(Guid id, UpdateUserReqDTO updateSchema);
        Task DeleteUserAsync(Guid id);
        Task<GetUserResDTO?> GetUserByAttribute(string? phoneNumber);
        Task UpdateUserRefreshTokenAsync(Guid id, string refreshToken, DateTime dateTimeAdd60Days);
        Task<GetUserResDTO?> GetUserAndCheckRefreshToken(Guid id, string refreshToken);
        Task InvalidateRefreshToken(Guid id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly SwimmingAppDBContext _context;

        public UserRepository(SwimmingAppDBContext context)
        {
            _context = context;
        }

        public async Task<List<GetUserResDTO>> GetUsersByQueryAsync(GetUsersQuery query)
        {

            var foundUsers = await _context.Users
                .Where(x => query.NameContains != null && x.Name.Contains(query.NameContains))
                .Skip((query.PageNumber - 1) * 10)
                .Take(10)
                .ToListAsync();

            var getUserResDTOs = foundUsers.Select(user => new GetUserResDTO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age ?? null,
                UserType = user.UserType,
            }).ToList();

            return getUserResDTOs;
        }

        public async Task<GetUserResDTO?> GetUserByIdAsync(Guid id)
        {
            var foundUser = await _context.Users.FindAsync(id);

            if (foundUser == null)
            {
                return null;
            }
            var getUserResDTO = new GetUserResDTO
            {
                Id = foundUser.Id,
                Name = foundUser.Name,
                Age = foundUser.Age ?? null,
                UserType = foundUser.UserType,
            };
            return getUserResDTO;
        }

        public async Task<GetUserResDTO> CreateUserAsync(CreateUserReqDTO userSchema)
        {
            var user = new User
            {
                Name = userSchema.Name,
                PhoneNumber = userSchema.PhoneNumber,
                Email = userSchema.Email ?? null,
                Age = userSchema.Age ?? null,
                UserType = userSchema.UserType,

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var getUserResDTO = new GetUserResDTO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age ?? null,
                UserType = user.UserType,
            };
            return getUserResDTO;
        }

        public async Task<GetUserResDTO?> UpdateUserAsync(Guid id, UpdateUserReqDTO updateSchema)
        {
            var foundUser = await _context.Users.FindAsync(id);

            if (foundUser == null)
            {
                return null;
            }

            if (updateSchema.Name != null) foundUser.Name = updateSchema.Name;
            if (updateSchema.Age != null) foundUser.Age = updateSchema.Age;
            if (updateSchema.Email != null) foundUser.Email = updateSchema.Email;

            _context.Users.Update(foundUser);
            await _context.SaveChangesAsync();

            var getUserResDTO = new GetUserResDTO
            {
                Id = foundUser.Id,
                Name = foundUser.Name,
                Age = foundUser.Age ?? null,
                UserType = foundUser.UserType,
            };
            return getUserResDTO;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<GetUserResDTO?> GetUserByAttribute(string? phoneNumber)
        {
            // Check if phone number is not null
            // If null, return null
            if (phoneNumber != null)
            {
                var foundUser = await _context.Users
                    .Where(x => x.PhoneNumber == phoneNumber)
                    .FirstOrDefaultAsync();

                if (foundUser == null)
                {
                    return null;
                }
                var getUserResDTO = new GetUserResDTO
                {
                    Id = foundUser.Id,
                    Name = foundUser.Name,
                    Age = foundUser.Age ?? null,
                    UserType = foundUser.UserType,
                };
                return getUserResDTO;
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateUserRefreshTokenAsync(Guid id, string refreshToken, DateTime dateTimeAdd60Days)
        {
            var foundUser = await _context.Users.FindAsync(id);

            foundUser.RefreshToken = refreshToken;
            foundUser.RefreshTokenExpiry = dateTimeAdd60Days;

            _context.Users.Update(foundUser);
            await _context.SaveChangesAsync();
        }

        public async Task<GetUserResDTO?> GetUserAndCheckRefreshToken(Guid id, string refreshToken)
        {
            var foundUser = await _context.Users.FindAsync(id);

            if (foundUser == null)
            {
                return null;
            }

            if (foundUser.RefreshToken == refreshToken)
            {
                // Check expiration date
                if (foundUser.RefreshTokenExpiry != null && foundUser.RefreshTokenExpiry > DateTime.UtcNow)
                {
                    var getUserResDTO = new GetUserResDTO
                    {
                        Id = foundUser.Id,
                        Name = foundUser.Name,
                        Age = foundUser.Age ?? null,
                        UserType = foundUser.UserType,
                    };
                    return getUserResDTO;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task InvalidateRefreshToken(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            user!.RefreshToken = null;
            user!.RefreshTokenExpiry = null;

            await _context.SaveChangesAsync();
            // No need to return anything, just invalidate the token
        }
    }

}