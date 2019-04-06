using AklimaGeldikce.DbContext;
using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Repositories
{
    public class RoleMenuItemRepository : BaseRepository<RoleMenuItem>, IRoleMenuItemRepository
    {
        public RoleMenuItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
