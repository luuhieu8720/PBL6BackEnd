﻿using PBL6BackEnd.DTO.UserDTO;
using PBL6BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public interface IUserRepository
    {
        Task Create(UserForm userForm);

        Task<User> GetById(Guid Id);
    }
}
