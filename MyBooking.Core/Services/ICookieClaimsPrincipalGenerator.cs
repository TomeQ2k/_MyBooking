using System.Collections.Generic;
using System.Security.Claims;
using MyBooking.Core.Entities;

namespace MyBooking.Core.Services
{
    public interface ICookieClaimsPrincipalGenerator
    {
        ClaimsPrincipal GenerateCookieClaimsPrincipal(User user, bool isPersistent = true, IEnumerable<Claim> customClaims = null);
    }
}