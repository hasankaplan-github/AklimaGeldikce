using AklimaGeldikce.DbContext;
using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
