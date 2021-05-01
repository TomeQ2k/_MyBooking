using System.Collections.Generic;
using System.Security.Claims;
using MyBooking.Core.Extensions;
using MyBooking.Core.Helpers;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class CookieClaimsPrincipalGenerator : ICookieClaimsPrincipalGenerator
    {
        public ClaimsPrincipal GenerateCookieClaimsPrincipal(User user, bool isPersistent = true, IEnumerable<Claim> customClaims = null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            }
            .AddRoleClaim(user.UserRoles);

            if (customClaims != null)
                claims.AddRange(customClaims);

            var identity = new ClaimsIdentity(claims, Constants.AuthCookiesDefaultScheme);
            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}