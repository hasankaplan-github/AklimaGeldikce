using AklimaGeldikce.DbContext;
using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
