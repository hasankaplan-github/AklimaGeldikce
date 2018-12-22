using System.Collections.Generic;
using AklimaGeldikce.Repositories.UnitOfWork;
using AklimaGeldikce.Entities;

namespace AklimaGeldikce.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Role> GetManyByNames(params string[] roleNames)
        {
            IList<Role> roles = new List<Role>(roleNames.Length);
            foreach (var roleName in roleNames)
            {
                roles.Add(base.repository.Get(r => r.Name == roleName));
            }

            return roles;
        }
    }
}
