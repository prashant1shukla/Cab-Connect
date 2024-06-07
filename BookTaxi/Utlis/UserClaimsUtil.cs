using System.Security.Claims;

namespace BookTaxi.Utlis
{
    public class UserClaimsUtil
    {
        // Gives the Email from the JWT Token.
        public static string? GetUserEmailClaim(ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }

        // Gives the UserType from the JWT Token.
        public static string? GetUserTypeClaim(ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;
        }
    }
}
