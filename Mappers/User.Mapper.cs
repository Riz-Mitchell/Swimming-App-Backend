using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Mappers
{
    public static class UserMapper
    {
        public static GetUserDTO MapGetUserDTO(this User userModel)
        {
            var returnUser = new GetUserDTO
            {
                Id = userModel.Id,
                Name = userModel.Name,
                UserType = userModel.UserType,
            };

            if (userModel.Age != null)
            {
                returnUser.Age = userModel.Age;
            }

            return returnUser;
        }

        public static User MapCreateUserDTO(this CreateUserDTO createUserDTO)
        {
            var createdUser = new User
            {
                PhoneNumber = createUserDTO.PhoneNumber,
                Name = createUserDTO.Name,
                UserType = createUserDTO.UserType,
            };

            // Optionals
            if (createUserDTO.Age != null)
            {
                createdUser.Age = createUserDTO.Age;
            }

            if (createUserDTO.Email != null)
            {
                createdUser.Email = createUserDTO.Email;
            }

            return createdUser;
        }
    }
}