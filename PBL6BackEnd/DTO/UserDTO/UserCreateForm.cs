using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.DTO.UserDTO
{
    public class UserCreateForm
    {
        [Required(ErrorMessage = "Username cannot be null")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be null")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name cannot be null")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be null")]
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Phone number cannot be null")]
        public string Phone { get; set; }
    }
}
