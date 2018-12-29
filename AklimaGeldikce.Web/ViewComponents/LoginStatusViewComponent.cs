using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AklimaGeldikce.Entities;
using AklimaGeldikce.Services;
using Microsoft.AspNetCore.Mvc;

namespace AklimaGeldikce.Web.ViewComponents
{
    public class LoginStatusViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public LoginStatusViewComponent(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string loggedInUserId = Request.Cookies["loggedInUserId"];
            if (IsLoggedIn(loggedInUserId))
            {
                User user = this.userService.GetById(Guid.Parse(loggedInUserId));
                return View("LoggedIn", user.Username);
            }
            return View();
        }

        private bool IsLoggedIn(string loggedInUserId)
        {
            if (string.IsNullOrEmpty( loggedInUserId ) || loggedInUserId.Equals(Guid.Empty))
            {
                return false;
            }
            return true;
        }

    }
}