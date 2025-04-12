using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin.Auth;

namespace SwimmingAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITwilioService _twilioService;

        public AuthController(ITwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        [HttpPost("generate-otp")]
        public async Task<IActionResult> GenerateOTP([FromBody] OTPRequest otpRequest)
        {
            var phoneNum = otpRequest.PhoneNum;

            await _twilioService.SendVerificationCodeAsync(phoneNum);

            return NoContent();
        }

        [HttpPost("validate-otp")]
        public async Task<IActionResult> ValidateOTP([FromBody] OTPSubmit otpSubmit)
        {
            var phoneNum = otpSubmit.PhoneNum;

            var OTP = otpSubmit.OTP;

            if (_twilioService.ValidateVerificationCode(phoneNum, OTP))
            {
                // Return the user token
            }

            return Unauthorized("Incorrect phone or password");
        }
    }

    public class OTPRequest
    {
        public required string PhoneNum { get; set; }
    }

    public class OTPSubmit
    {
        public required string PhoneNum { get; set; }
        public required string OTP { get; set; }
    }
}