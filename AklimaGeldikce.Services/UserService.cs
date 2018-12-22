using System;
using System.Collections.Generic;
using System.Text;
using AklimaGeldikce.Entities;
using AklimaGeldikce.Repositories;
using AklimaGeldikce.Repositories.UnitOfWork;
using System.Linq;

namespace AklimaGeldikce.Services
{
    public class UserService :BaseService<User>, IUserService
    {
        private readonly IRepository<RoleUser> roleUserRepository;
        private readonly IRepository<Role> roleRepository;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.roleUserRepository = unitOfWork.GetRepository<RoleUser>();
            this.roleRepository = unitOfWork.GetRepository<Role>();
        }
        
        public User Register(User newUser, params string[] roleNames)
        {
            var existingUser = base.repository.Get(u => u.Username.Equals(newUser.Username));
            if (existingUser != null) return null; // there is already a user with that username.

            base.repository.Add(newUser);
            foreach (var roleName in roleNames)
            {
                var role = this.roleRepository.Get(r => r.Name.Equals(roleName));
                var newRoleUser = new RoleUser() { RoleId = role.Id, UserId = newUser.Id };
                this.roleUserRepository.Add(newRoleUser);
            }
            base.unitOfWork.SaveChanges();

            return newUser;
        }
    }
}
