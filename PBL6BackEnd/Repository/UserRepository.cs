using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBL6BackEnd.DTO.AuthDTO;
using PBL6BackEnd.DTO.UserDTO;
using PBL6BackEnd.Exceptions;
using PBL6BackEnd.Extensions;
using PBL6BackEnd.Model;
using PBL6BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        private readonly IAuthenticationService authenticationService;

        public UserRepository(DataContext dataContext, IAuthenticationService authenticationService)
        {
            this.dataContext = dataContext;
            this.authenticationService = authenticationService;
        }

        public async Task Create(UserCreateForm userForm)
        {
            if (await dataContext.Users.AnyAsync(x => x.Username == userForm.Username))
                throw new BadRequestException("This username has already been registered");

            userForm.Password = userForm.Password.Encrypt();
            var user = userForm.ConvertTo<User>();

            user.Role = Role.User;

            await dataContext.AddAsync(user);
            await dataContext.SaveChangesAsync();
        }

        public async Task<User> GetById(Guid Id)
        {
            return await dataContext.Users.FindAsync(Id) ?? 
                throw new NotFoundException("Item can't be found");
        }

        public async Task Update(UserUpdateForm userUpdateForm)
        {
            var currentUserId = authenticationService.CurrentUserId;

            var user = await GetById(currentUserId);

            userUpdateForm.CopyTo(user);

            dataContext.Entry(user).State = EntityState.Modified;

            await dataContext.SaveChangesAsync();
        }

        public async Task ChangePassword(PasswordForm passwordForm)
        {
            var currentUserId = authenticationService.CurrentUserId;

            var user = await GetById(currentUserId);

            if (!string.IsNullOrEmpty(passwordForm.OldPassword))
            {
                if (passwordForm.OldPassword.Encrypt() != user.Password)
                {
                    throw new BadRequestException("The old password is incorrect");
                }

                else if (passwordForm.NewPassword != passwordForm.ConfirmPassword)
                {
                    throw new BadRequestException("New password and confirmation password must match");
                }

                user.Password = passwordForm.NewPassword.Encrypt();
            }

            dataContext.Entry(user).State = EntityState.Modified;

            await dataContext.SaveChangesAsync();
        } 

        public async Task<List<UserItem>> Get()
        {
            return await dataContext.Users
                .Select(x => x.ConvertTo<UserItem>())
                .ToListAsync();
        }

        public async Task<UserDetail> GetByUsername(string username)
        {
            var user = await dataContext.Users
                .Where(x => x.Username == username)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new NotFoundException("This username does not exist");
            }

            return user.ConvertTo<UserDetail>();
        }
    }
}
