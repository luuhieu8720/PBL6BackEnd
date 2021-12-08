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
            Phone = user.Phone;
            Birthday = user.BirthDay;
            Role = user.Role;
        }

        public AuthenUser(ClaimsIdentity claimsIdentity, User user)
        {
            Id = Guid.Parse(claimsIdentity.GetClaimValue(ClaimTypes.NameIdentifier));
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = claimsIdentity.GetClaimValue(ClaimTypes.Upn);
            Phone = claimsIdentity.GetClaimValue(ClaimTypes.MobilePhone);
            Birthday = DateTime.Parse(claimsIdentity.GetClaimValue(ClaimTypes.DateOfBirth));
            Role = claimsIdentity.GetClaimValue(ClaimTypes.Role).ToEnum<Role>();
        }

        public Claim[] GetClaims()
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.GivenName, FirstName ?? string.Empty),
                new Claim(ClaimTypes.Surname, LastName ?? string.Empty),
                new Claim(ClaimTypes.Upn, Username),
                new Claim(ClaimTypes.MobilePhone, Phone),
                new Claim(ClaimTypes.DateOfBirth, Birthday.ToString()),
                new Claim(ClaimTypes.Role, Role.ToString())
            };

            return claims;
        }
    }
}
