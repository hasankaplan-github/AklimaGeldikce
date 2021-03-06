using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AklimaGeldikce.Services
{
    public interface IUserService : IBaseService<User>
    {
        User Register(User newUser, params string[] roleNames);
    }
}
