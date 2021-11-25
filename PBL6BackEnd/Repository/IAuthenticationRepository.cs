using PBL6BackEnd.DTO.AuthDTO;
using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public interface IAuthenticationRepository
    {
        Task<User> Login(LoginForm loginForm);
    }
}
