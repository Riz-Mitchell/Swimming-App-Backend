using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Api.DTOs
{
    // DTO for querying users
    public class GetUsersQuery
    {
        public string? NameContains { get; set; }
        public string? OrderBy { get; set; } // Property to specify the field to order by
        public bool IsAscending { get; set; } = true; // Property to specify ascending or descending order
        public int PageNumber { get; set; } = 1; // Page number to retrieve
    }

    // DTO for user response
    public class GetUserResDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public int? Age { get; set; }
        public UserType UserType { get; set; }
    }

    // DTO for creating a user
    public class CreateUserReqDTO
    {
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public UserType UserType { get; set; }
    }

    // DTO for updating a user
    public class UpdateUserReqDTO
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
    }
}