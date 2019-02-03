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
        private readonly IRoleService roleService;
        private readonly IMenuItemService menuItemService;

        public SideBarViewComponent(IRoleService roleService, IMenuItemService menuItemService)
        {
            this.roleService = roleService;
            this.menuItemService = menuItemService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string dynamicNavbarCookie = Request.Cookies["dynamicNavbar"];
            if (string.IsNullOrEmpty(dynamicNavbarCookie))
            {
                var roles = await this.roleService.GetManyAsync(r => r.Name == "Guest");
                dynamicNavbarCookie = await this.menuItemService.GetSidebarHtmlAsync(null, roles);
                HttpContext.Response.Cookies.Append("dynamicNavbar", dynamicNavbarCookie);
            }
            return View("Default_AdminLte", dynamicNavbarCookie);
        }
    }
}
