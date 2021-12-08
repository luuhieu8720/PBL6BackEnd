using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PBL6BackEnd.Extensions;

namespace PBL6BackEnd.DTO.UserDTO
{
    public class AuthenUser : BaseUser
    {
        public AuthenUser(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Role = user.Role;
        }

        public AuthenUser(ClaimsIdentity claimsIdentity)
        {
            Id = Guid.Parse(claimsIdentity.GetClaimValue(ClaimTypes.NameIdentifier));
            FirstName = claimsIdentity.GetClaimValue(ClaimTypes.GivenName);
            LastName = claimsIdentity.GetClaimValue(ClaimTypes.Surname);
            Username = claimsIdentity.GetClaimValue(ClaimTypes.Upn);
            Role = claimsIdentity.GetClaimValue(ClaimTypes.Role).ToEnum<Role>();
        }

        public Claim[] GetClaims()
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.GivenName, FirstName ?? string.Empty),
                new Claim(ClaimTypes.Surname, LastName ?? string.Empty),
                new Claim(ClaimTypes.Upn, Username),
                new Claim(ClaimTypes.Role, Role.ToString())
            };

            return claims;
        }
    }
}
