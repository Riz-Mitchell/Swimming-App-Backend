namespace SwimmingAppBackend.Api.DTOs
{
    public class VerifiedDecodedDataDTO<T>
    {
        public T? DecodedPayload { get; set; }
        public bool IsValid { get; set; }
    }
}