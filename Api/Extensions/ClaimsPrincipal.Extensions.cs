using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens; // for JwtRegisteredClaimNames

namespace SwimmingAppBackend.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid? GetUserId(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                return null;
            }

            var userIdClaim = user.Claims.FirstOrDefault(c =>
                c.Type == JwtRegisteredClaimNames.Sub || c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
                return null;
            }

            return userId;
        }
    }
}
