using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.DTO.UserDTO
{
    public class UserItem
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public Role Role { get; set; }
    }
}
