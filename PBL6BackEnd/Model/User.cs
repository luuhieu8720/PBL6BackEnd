using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Model
{
    public class User : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Phone { get; set; }

        public Role Role { get; set; }

        public bool IsBlocked { get; set; }
    }
}
