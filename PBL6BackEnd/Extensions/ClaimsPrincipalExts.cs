using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PBL6BackEnd.Extensions
{
    public static class ClaimsPrincipalExts
    {
        public static string GetClaimValue(this ClaimsIdentity claimsIdentity, string claimType)
        {
            return claimsIdentity.Claims.First(claim => claim.Type == claimType)?.Value;
        }
    }
}
