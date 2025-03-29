using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.DataTransferObjects
{

    public class GetUserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UserType UserType { get; set; }

        public int? Age { get; set; }
    }


    public class UpdateUserDTO
    {
        public string? PhoneNumber { get; set; }

        public string? Name { get; set; }

        public int? Age { get; set; }

        public string? Email { get; set; }
    }

    public class CreateUserDTO
    {
        public required string PhoneNumber { get; set; }

        public required string Name { get; set; }

        public required UserType UserType { get; set; }

        public int? Age { get; set; }

        public string? Email { get; set; }
    }
}