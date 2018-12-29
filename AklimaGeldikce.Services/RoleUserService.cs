using AklimaGeldikce.Entities;
using AklimaGeldikce.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Services
{
    public class RoleUserService : BaseService<RoleUser>, IRoleUserService
    {
        public RoleUserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
