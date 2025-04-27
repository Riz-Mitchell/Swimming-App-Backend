
namespace SwimmingAppBackend.Api.DTOs
{
    public class GetTimeSheetResDTO
    {
        public required Guid Id { get; set; }
        public required int Interval { get; set; }
        public required int StartInterval { get; set; }
        public required Guid EventId { get; set; }
        public required ICollection<GetTimeSheetItemResDTO> TimeSheetItems { get; set; }
    }

    public class CreateTimeSheetReqDTO
    {
        public required int Interval { get; set; }
        public required int StartInterval { get; set; }
        public required ICollection<CreateTimeSheetItemReqDTO> TimeSheetItems { get; set; }
        public required Guid EventId { get; set; }
    }

    public class UpdateTimeSheetReqDTO
    {
        public int? Interval { get; set; }
        public int? StartInterval { get; set; }
        public ICollection<UpdateTimeSheetItemReqDTO>? TimeSheetItems { get; set; }
        public Guid? EventId { get; set; }
    }
}