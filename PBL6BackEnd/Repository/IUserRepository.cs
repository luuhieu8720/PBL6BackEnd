using PBL6BackEnd.DTO.AuthDTO;
using PBL6BackEnd.DTO.UserDTO;
using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public interface IUserRepository
    {
        Task Create(UserCreateForm userForm);

        Task<User> GetById(Guid Id);

        Task Update(UserUpdateForm userUpdateForm);

        Task ChangePassword(PasswordForm passwordForm);

        Task<List<UserItem>> Get();

        Task<UserDetail> GetByUsername(string username);

        Task Block(string username);
    }
}
