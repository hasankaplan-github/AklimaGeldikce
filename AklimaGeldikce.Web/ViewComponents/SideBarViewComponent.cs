using AklimaGeldikce.Entities;
using AklimaGeldikce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Web.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public SideBarViewComponent(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string loggedInUserId = Request.Cookies["loggedInUserId"];
            if (IsLoggedIn(loggedInUserId))
            {
                User user = this.userService.GetById(Guid.Parse(loggedInUserId));
                return View("LoggedIn_AdminLte", user.Username);
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
