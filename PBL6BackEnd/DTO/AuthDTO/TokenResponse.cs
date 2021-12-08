using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.DTO.AuthDTO
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public Role Role { get; set; }
    }
}
