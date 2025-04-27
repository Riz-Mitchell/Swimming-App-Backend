namespace SwimmingAppBackend.Api.DTOs
{
    public class GetTimetablesQuery
    {
        public DateTime? StartDateRange { get; set; }
        public DateTime? EndDateRange { get; set; }
        public string? NameContains { get; set; }
        public int PageNumber { get; set; } = 1;
    }

    public class GetTimetableResDTO
    {
        public required Guid Id { get; set; }
        public required Guid SquadId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateTimetableReqDTO
    {
        public required Guid SquadId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }
    }

    public class UpdateTimetableReqDTO
    {
        public Guid? SquadId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }
    }
}