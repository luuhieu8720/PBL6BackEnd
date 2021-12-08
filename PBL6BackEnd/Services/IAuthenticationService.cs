using PBL6BackEnd.DTO.AuthDTO;
using PBL6BackEnd.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    
namespace PBL6BackEnd.Services
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> Login(LoginForm loginForm);

        AuthenUser CurrentUser { get; }

        Guid CurrentUserId { get; }
    }
}
