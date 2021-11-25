using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.DTO.AuthDTO
{
    public class LoginForm
    {
        [Required(ErrorMessage = "Username cannot be null")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password cannot be null")]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
