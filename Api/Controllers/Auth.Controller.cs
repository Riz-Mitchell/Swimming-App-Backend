using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin.Auth;
using SwimmingAppBackend.Domain.Services;
using System.Data;
using System;

namespace SwimmingAppBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITwilioService _twilioService;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public AuthController(ITwilioService twilioService, IJwtService jwtService, IUserService userService)
        {
            _userService = userService;
            _twilioService = twilioService;
            _jwtService = jwtService;
        }

        [HttpPost("generate-otp")]
        public async Task<IActionResult> GenerateOTP([FromBody] OTPRequest otpRequest)
        {
            var phoneNum = otpRequest.PhoneNum;

            // Validate user exists
            var foundUser = await _userService.GetUserByPhoneNumber(phoneNum);

            if (foundUser == null)
            {
                return Unauthorized();
            }

            // This shit will spend money!!!!!
            await _twilioService.SendVerificationCodeAsync(phoneNum);

            return Accepted();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginReq)
        {
            var phoneNum = loginReq.PhoneNum;

            var OTP = loginReq.OTP;

            if (!_twilioService.ValidateVerificationCode(phoneNum, OTP))
            {
                return Unauthorized();
            }

            var foundUser = await _userService.GetUserByPhoneNumber(phoneNum);

            if (foundUser == null)
            {
                return Unauthorized();
            }

            var accessToken = _jwtService.GenerateAccessToken(foundUser);
            var refreshToken = _jwtService.GenerateRefreshToken();

            await _userService.SaveRefreshTokenAsync(foundUser.Id, refreshToken, DateTime.UtcNow.AddDays(60));

            Response.Cookies.Append("AccessToken", accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,                        // Use Secure in production (HTTPS)
                SameSite = SameSiteMode.Strict,       // Adjust SameSite setting as needed
                Expires = DateTime.UtcNow.AddMinutes(30)
            });

            Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(60)
            });

            return Ok(new { message = "Logged in successfully" });
        }

        [HttpPost("refresh/{id}")]
        public async Task<IActionResult> Refresh(Guid id)
        {
            // Read the refresh token from the cookie
            if (!Request.Cookies.TryGetValue("RefreshToken", out var refreshToken))
            {
                return Unauthorized("No refresh token provided");
            }

            // Validate refresh token (check database or in-memory store)
            var foundUser = await _userService.FindUserAndRefreshToken(id, refreshToken);
            if (foundUser == null)
            {
                return Unauthorized("Invalid refresh token");
            }


            var newAccessToken = _jwtService.GenerateAccessToken(foundUser);

            // Set new access token cookie
            Response.Cookies.Append("AccessToken", newAccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(30)
            });

            // If a new refresh token was issued, update its cookie similarly.

            return Ok(new { message = "Token refreshed" });
        }

    }

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