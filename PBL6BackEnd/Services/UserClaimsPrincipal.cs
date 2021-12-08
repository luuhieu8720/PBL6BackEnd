using PBL6BackEnd.DTO.UserDTO;
using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace PBL6BackEnd.Services
{
    public class UserClaimsPrincipal : ClaimsPrincipal
    {
        public AuthenUser AuthenUser { get; private set; }
        public UserClaimsPrincipal(ClaimsIdentity claimsIdentity, User user) : base(claimsIdentity)
        {
            AuthenUser = new AuthenUser(claimsIdentity, user);
        }
    }
}
