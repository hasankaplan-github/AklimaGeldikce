using AklimaGeldikce.DbContext;
using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
