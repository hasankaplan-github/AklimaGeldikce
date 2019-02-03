using AklimaGeldikce.Entities;
using AklimaGeldikce.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Services
{
    public class NotificationService : BaseService<Notification>, INotificationService
    {
        public NotificationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
