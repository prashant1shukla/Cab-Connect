using System.Security.Claims;

namespace BookTaxi.Utlis
{
    public class UserClaimsUtil
    {
        public static string? GetUserEmailClaim(ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }

        public static string? GetUserTypeClaim(ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;
        }
    }
}
