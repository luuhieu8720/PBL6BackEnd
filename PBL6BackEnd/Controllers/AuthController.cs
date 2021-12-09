using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBL6BackEnd.DTO.AuthDTO;
using PBL6BackEnd.DTO.UserDTO;
using PBL6BackEnd.Repository;
using PBL6BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly IAuthenticationService authenticationService;
        private readonly IAuthenticationRepository authenticationRepository;

        public AuthController(IAuthenticationService authenticationService, 
            IUserRepository repository,
            IAuthenticationRepository authenticationRepository)
        {
            this.authenticationService = authenticationService;
            this.repository = repository;
            this.authenticationRepository = authenticationRepository;
        }

        [HttpPost("signup")]
        public async Task Create([FromBody] UserCreateForm userForm) => await repository.Create(userForm);

        [HttpPost("signin")]
        public async Task<TokenResponse> Post([FromBody] LoginForm loginForm) => await authenticationService.Login(loginForm);

        [HttpGet]
        [Authorize]
        public AuthenUser Get() => authenticationService.CurrentUser;
    }
}
