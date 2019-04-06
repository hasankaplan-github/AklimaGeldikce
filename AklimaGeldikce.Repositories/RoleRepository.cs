using AklimaGeldikce.DbContext;
using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
