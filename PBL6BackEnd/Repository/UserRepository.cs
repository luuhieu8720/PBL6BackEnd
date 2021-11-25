using Microsoft.EntityFrameworkCore;
using PBL6BackEnd.DTO.UserDTO;
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
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task Create(UserForm userForm)
        {
            if (await dataContext.Users.AnyAsync(x => x.Username == userForm.Username))
                throw new BadRequestException("This username has already been registered");

            userForm.Password = userForm.Password.Encrypt();
            var user = userForm.ConvertTo<User>();

            user.Role = Role.Manager;

            await dataContext.AddAsync(user);
            await dataContext.SaveChangesAsync();
        }

        public async Task<User> GetById(Guid Id)
        {
            return await dataContext.Users.FindAsync(Id);
        }
    }
}
