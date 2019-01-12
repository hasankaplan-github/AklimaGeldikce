using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AklimaGeldikce.Services;
using Microsoft.AspNetCore.Mvc;

namespace AklimaGeldikce.Web.Controllers
{
    public class DynamicNavbarViewComponent : ViewComponent
    {
        private readonly IMenuItemService menuItemService;
        private readonly IRoleService roleService;

        public DynamicNavbarViewComponent(IMenuItemService menuItemService, IRoleService roleService)
        {
            this.menuItemService = menuItemService;
            this.roleService = roleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string dynamicNavbarCookie = Request.Cookies["dynamicNavbar"];
            if (string.IsNullOrEmpty(dynamicNavbarCookie))
            {
                var roles = await this.roleService.GetManyAsync(r => r.Name == "Guest");
                dynamicNavbarCookie = await this.menuItemService.GetNavbarHtmlAsync(null, roles, false);
                HttpContext.Response.Cookies.Append("dynamicNavbar", dynamicNavbarCookie);
            }
            return View("Default",dynamicNavbarCookie);
        }
    }
}