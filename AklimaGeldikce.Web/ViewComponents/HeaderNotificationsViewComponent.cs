using AklimaGeldikce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AklimaGeldikce.Entities;

namespace AklimaGeldikce.Web.ViewComponents
{
    public class HeaderNotificationsViewComponent : ViewComponent
    {
        private readonly INotificationService notificationService;
        
        public HeaderNotificationsViewComponent(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string loggedInUserId = Request.Cookies["loggedInUserId"];
            if (IsLoggedIn(loggedInUserId))
            {
                var unreadNotifications = await this.notificationService.GetManyAsync(x => x.ToId == Guid.Parse(loggedInUserId) && x.IsRead == false, x => x.OrderByDescending(y => y.NotificationDate));

                return View("LoggedIn_AdminLte", unreadNotifications);
            }
            return View("Default_AdminLte");
        }

        private bool IsLoggedIn(string loggedInUserId)
        {
            if (string.IsNullOrEmpty(loggedInUserId) || loggedInUserId.Equals(Guid.Empty.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
