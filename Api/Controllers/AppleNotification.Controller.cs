using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin.Auth;
using SwimmingAppBackend.Domain.Services;
using System.Data;
using System;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using SwimmingAppBackend.Api.DTOs;

namespace SwimmingAppBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppleController : ControllerBase
    {
        public readonly IAppleNotificationService _appleNotificationService;

        public AppleController(IAppleNotificationService appleNotificationService)
        {
            _appleNotificationService = appleNotificationService;
        }

        [AllowAnonymous]
        [HttpPost("/store-notifications")]
        public async Task<IActionResult> AppleNotification([FromBody] AppleNotificationReqDTO appleNotificationReq)
        {
            try
            {
                _appleNotificationService.HandleNotification(appleNotificationReq);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}