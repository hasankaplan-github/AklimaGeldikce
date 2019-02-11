using AklimaGeldikce.Entities;
using AklimaGeldikce.Services;
using AklimaGeldikce.Web.Code;
using AklimaGeldikce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Web.ViewComponents
{
    public class MyProfileUserInfoViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public MyProfileUserInfoViewComponent(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Guid loggedInUserId = Guid.Parse(Request.Cookies[CookieKeys.LoggedInUserId]);
            User user = this.userService.GetById(loggedInUserId);
            if (user == null)
            {
                return View("Default_AdminLte");
            }
            MyProfileUserInfoViewModel myProfileUserInfoViewModel = new MyProfileUserInfoViewModel
            {
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Email = user.Email,
                Username = user.Username
            };
            return View("Default_AdminLte", myProfileUserInfoViewModel);
        }
    }
}
