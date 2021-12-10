using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.DTO.UserDTO
{
    public class UserUpdateForm
    {
        [Required(ErrorMessage = "First name cannot be null")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be null")]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Phone number cannot be null")]
        public string Phone { get; set; }
    }
}
