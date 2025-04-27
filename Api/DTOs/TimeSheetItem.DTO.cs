namespace SwimmingAppBackend.Api.DTOs
{
    public class GetTimeSheetItemResDTO
    {
        public required Guid Id { get; set; }
        public required double Time { get; set; }
        public required double CurrentInterval { get; set; }
    }

    public class CreateTimeSheetItemReqDTO
    {
        public required double Time { get; set; }
        public required double CurrentInterval { get; set; }
    }
    public class UpdateTimeSheetItemReqDTO
    {
        public double Time { get; set; }
        public double CurrentInterval { get; set; }
    }
}