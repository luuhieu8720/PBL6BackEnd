using Microsoft.EntityFrameworkCore;
using PBL6BackEnd.DTO.AuthDTO;
using PBL6BackEnd.Exceptions;
using PBL6BackEnd.Extensions;
using PBL6BackEnd.Model;
using PBL6BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext dataContext;

        public AuthenticationRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<User> Login(LoginForm loginForm)
        {
            var test = await dataContext.Users
                            .FirstOrDefaultAsync(x => x.Username == loginForm.Username && x.Password == loginForm.Password.Encrypt())
                           ?? throw new BadRequestException("Wrong username or password");
            return test;
        }
    }
}
