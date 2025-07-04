namespace SwimmingAppBackend
{
    public class OTPRequest
    {
        public required string PhoneNum { get; set; }
    }

    public class LoginRequest
    {
        public required string PhoneNum { get; set; }
        public required string OTP { get; set; }
    }
}