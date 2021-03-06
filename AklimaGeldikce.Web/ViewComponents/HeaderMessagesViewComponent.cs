using AklimaGeldikce.Web.Code;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Web.ViewComponents
{
    public class HeaderMessagesViewComponent : ViewComponent
    {
        public HeaderMessagesViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string loggedInUserId = Request.Cookies[CookieKeys.LoggedInUserId];
            if (IsLoggedIn(loggedInUserId))
            {
                //User user = this.userService.GetById(Guid.Parse(loggedInUserId));
                //return View("LoggedIn_AdminLte", user.Username);

                return View("LoggedIn_AdminLte");
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
