using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using MyBooking.Core.Helpers;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Extensions
{
    public static class ClaimsExtensions
    {
        public static List<Claim> AddRoleClaim(this List<Claim> claims, IEnumerable<UserRole> userRoles)
        {
            if (userRoles.Any(ur => ur.Role.RoleName == Constants.AdminRole))
                claims.Add(new Claim(ClaimTypes.Role, Constants.AdminRole));

            return claims;
        }
    }
}