using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Services
{
    public interface IUserService : IBaseService<User>
    {
        User Register(User newUser, params string[] roleNames);
    }
}
