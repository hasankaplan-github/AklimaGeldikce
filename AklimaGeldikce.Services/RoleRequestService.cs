using AklimaGeldikce.Entities;
using AklimaGeldikce.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Services
{
    public class RoleRequestService : BaseService<RoleRequest>, IRoleRequestService
    {
        public RoleRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
