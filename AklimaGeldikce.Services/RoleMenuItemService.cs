using AklimaGeldikce.Entities;
using AklimaGeldikce.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Services
{
    public class RoleMenuItemService : BaseService<RoleMenuItem>, IRoleMenuItemService
    {
        public RoleMenuItemService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
