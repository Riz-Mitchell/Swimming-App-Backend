namespace SwimmingAppBackend
{
    public class OTPReqDTO
    {
        public required string PhoneNum { get; set; }
    }

    public class LoginReqDTO
    {
        public required string PhoneNum { get; set; }
        public required string OTP { get; set; }
    }

    public class LoginResDTO
    {
        public required Guid UserId { get; set; }
    }
}