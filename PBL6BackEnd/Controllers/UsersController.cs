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
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPut("update")]
        public async Task Update([FromBody]UserUpdateForm userUpdateForm) => await repository.Update(userUpdateForm);

        [HttpPut("password")]
        public async Task ChangePassword([FromBody] PasswordForm passwordForm) => await repository.ChangePassword(passwordForm);

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<List<UserItem>> Get() => await repository.Get();

        [HttpGet("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<UserDetail> Get(string username) => await repository.GetByUsername(username);
    }
}
